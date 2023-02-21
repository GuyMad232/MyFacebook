using DeepAI;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Threading;

namespace BasicFacebookFeatures
{
    public partial class FormMain : Form
    {
        private User m_LoggedInUser;
        private readonly FormLogin r_FormLogin = StaticFormFactory.CreateFormFactory(nameof(FormLogin)) as FormLogin;
        private readonly FormLeaderBoard r_FormLeaderBoard;
        private List<PictureBox> m_LikedPagesPictureBox = new List<PictureBox>();
        private List<PictureBox> m_FriendsPictureBox = new List<PictureBox>();
        private List<PictureBox> m_AlbumsPictureBox = new List<PictureBox>();
        private List<Label> m_AlbumsLabels = new List<Label>();
        private GuessingGame m_CurrentGame;
        private List<Button> m_GameAnswerButtons = new List<Button>();
        private List<string> m_FourCelebrities = new List<string>();
        private Timer m_TimerForMemoriesPicture = new Timer(5000);
        private GameResults m_GameResults;
        private const bool v_Active = true;
        private DarkMode m_DarkMode;
        private List<Control> m_Controls = new List<Control>();
        private Dictionary<Control, ControlProperties> m_ControlProperties = new Dictionary<Control, ControlProperties>();

        public FormMain()
        {
            r_FormLogin.ShowDialog();
            CreateHandle();
            if (r_FormLogin.m_LoginSucceed == true)
            {
                m_LoggedInUser = r_FormLogin.m_LoggedInUser;
                m_CurrentGame = new GuessingGame(getUserBirthMonth());
                m_GameResults = GameResults.CreateOrGetGameResults();
                m_DarkMode = new DarkMode();
                m_DarkMode.m_ReportClickedDelegates += this.displayModeChange;
                List<string> optionalParameters = new List<string> { m_LoggedInUser.Email, m_LoggedInUser.PictureNormalURL };
                r_FormLeaderBoard = StaticFormFactory.CreateFormFactory(nameof(FormLeaderBoard), optionalParameters) as FormLeaderBoard;
                InitializeComponent();
                setControlsList();
                setControlsProperties();
                m_Controls.Add(this);
                setDarkModeDisplay(m_DarkMode.GetDarkModeButton());
                this.Controls.Add(m_DarkMode.GetDarkModeButton());
                setLabelsList();
                insertMockPosts(FriendsPosts, false);
                setPictureBoxList();
                new Thread(showUserInfo).Start();
                setButtonsList();
                new Thread(showRandomFourPages).Start();
                setTimer();
            }
            else
            {
                MessageBox.Show(@"Sorry - login failed");
            }
        }

        private void setTimer()
        {
            m_TimerForMemoriesPicture.Elapsed += displayMemoriesPicture;
            m_TimerForMemoriesPicture.Start();
            m_TimerForMemoriesPicture.Enabled = true;
        }

        private void showUserInfo()
        {
            this.Invoke(new Action(() =>
            {
                userBindingSource.DataSource = m_LoggedInUser;

                if (m_LoggedInUser.Hometown != null)
                {
                    labelLocation.Text = $@"Your hometown is {m_LoggedInUser.Hometown}";
                }
                else if (m_LoggedInUser.Location != null)
                {
                    labelLocation.Text = m_LoggedInUser.Location.Name;
                }
                else
                {
                    labelLocation.Text = @"default - IDC Herzilia";
                }
            }));
        }

        private void setPictureBoxList()
        {
            m_LikedPagesPictureBox.Add(this.pictureBoxPage1);
            m_LikedPagesPictureBox.Add(this.pictureBoxPage2);
            m_LikedPagesPictureBox.Add(this.pictureBoxPage3);
            m_LikedPagesPictureBox.Add(this.pictureBoxPage4);
            m_FriendsPictureBox.Add(this.pictureBoxFriend1);
            m_FriendsPictureBox.Add(this.pictureBoxFriend2);
            m_FriendsPictureBox.Add(this.pictureBoxFriend3);
            m_FriendsPictureBox.Add(this.pictureBoxFriend4);
            m_AlbumsPictureBox.Add(this.pictureBoxAlbum1);
            m_AlbumsPictureBox.Add(this.pictureBoxAlbum2);
            m_AlbumsPictureBox.Add(this.pictureBoxAlbum3);
            m_AlbumsPictureBox.Add(this.pictureBoxAlbum4);
            m_AlbumsPictureBox.Add(this.pictureBoxAlbum5);
        }

        private void setLabelsList()
        {
            m_AlbumsLabels.Add(this.labelAlbum1);
            m_AlbumsLabels.Add(this.labelAlbum2);
            m_AlbumsLabels.Add(this.labelAlbum3);
            m_AlbumsLabels.Add(this.labelAlbum4);
            m_AlbumsLabels.Add(this.labelAlbum5);
        }
        private void setButtonsList()
        {
            m_GameAnswerButtons.Add(this.buttonAnswer1);
            m_GameAnswerButtons.Add(this.buttonAnswer2);
            m_GameAnswerButtons.Add(this.buttonAnswer3);
            m_GameAnswerButtons.Add(this.buttonAnswer4);
        }

        private void changeControlVisibility(Control i_Control, bool i_Status)
        {
            i_Control.Visible = i_Status;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
        }

        private void buttonPost_Click(object sender, EventArgs e)
        {
            try
            {
                m_LoggedInUser.PostStatus(textBoxStatus.Text);
                MessageBox.Show(@"Status posted");
            }
            catch (Exception)
            {
                MessageBox.Show(@"You don't have the relevant authentication to post");
            }
        }

        private void buttonViewMorePages_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxPages2, groupBoxPages1, "More");
            if (m_LoggedInUser.LikedPages.Count > 0)
            {
                this.Pages.DataSource = m_LoggedInUser.LikedPages;
            }
            else
            {
                MessageBox.Show(@"We couldn't find any liked pages - sorry");
            }
        }

        private void buttonViewMoreFriends_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxFriends2, groupBoxFriends1, "More");
            if (m_LoggedInUser.Friends.Count == 0)
            {
                addFriends(createMockFriends());
            }
            else
            {
                addFriends(m_LoggedInUser.Friends);
            }
        }

        private void addFriends(System.Collections.IEnumerable i_Friends)
        {
            foreach (string friend in i_Friends)
            {
                Friends.Items.Add(friend);
            }
        }

        private void buttonViewMoreAlbums_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxAlbums2, groupBoxAlbums1, "More");
            buttonViewLessAlbums.Visible = true;
        }

        private void buttonViewLessPages_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxPages2, groupBoxPages1, "Less");
        }

        private void buttonViewLessFriends_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxFriends2, groupBoxFriends1, "Less");
        }

        private void buttonViewLessAlbums_Click(object sender, EventArgs e)
        {
            changeViewButton(groupBoxAlbums2, groupBoxAlbums1, "Less");
        }

        private void changeViewButton(GroupBox io_GroupBox1, GroupBox io_GroupBox2, string i_Type)
        {
            if (i_Type == "Less")
            {
                changeControlVisibility(io_GroupBox1, !v_Active);
                changeControlVisibility(io_GroupBox2, v_Active);
            }
            else
            {
                changeControlVisibility(io_GroupBox1, v_Active);
                changeControlVisibility(io_GroupBox2, !v_Active);
            }
        }

        private void buttonGetAllPosts_Click(object sender, EventArgs e)
        {
            FilterStrategy filter = new FilterStrategy();
            filter.SetSelectionStrategy(new ShowAllFilter());
            Thread thread = new Thread(() => fetchFilteredPosts(filter));
            thread.Start();
        }

        private void fetchFilteredPosts(FilterStrategy i_FilterStratagy)
        {
            this.Invoke(new Action(() =>
            {
                listBoxPosts.Items.Clear();
                try
                {
                    if (m_LoggedInUser.Posts == null)
                    {
                        MessageBox.Show(@"You have zero authentic posts");
                        insertMockPosts(listBoxPosts, true);
                    }
                    else
                    {
                        foreach (Post post in i_FilterStratagy.Select(m_LoggedInUser.Posts.ToList()))
                        {
                            if (post.Message != null)
                            {
                                listBoxPosts.Items.Add(post.Message);
                            }
                            else if (post.Caption != null)
                            {
                                listBoxPosts.Items.Add(post.Caption);
                            }
                            else
                            {
                                listBoxPosts.Items.Add($"{post.Type}");
                            }
                        }
                    }
                }
                catch
                {
                    if (listBoxPosts.Items.Count == 0)
                    {
                        MessageBox.Show(@"we had an issue with retrieving this data - here is some mock data");
                        insertMockPosts(listBoxPosts, true);
                    }
                }
            }));
        }

        private void insertMockPosts(ListBox i_ListBoxName, bool i_IsPersonalPosts)
        {
            foreach (string mockPost in createMockPosts(i_IsPersonalPosts))
            {
                i_ListBoxName.Items.Add(mockPost);
            }
        }

        private void insertMockEvents()
        {
            foreach (string mockEvent in createMockEvents())
            {
                Events.Items.Add(mockEvent);
            }
        }

        private void showRandomFourPages()
        {
            this.Invoke(new Action(() =>
            {
                Random randomNumber = new Random();
                int i = 0;

                if (m_LoggedInUser.LikedPages.Count > 0)
                {
                    foreach (Page page in m_LoggedInUser.LikedPages.OrderBy(i_PageRandom => randomNumber.Next()).Take(4))
                    {
                        m_LikedPagesPictureBox[i].LoadAsync(page.PictureLargeURL);
                        i++;
                    }
                }
            }));
        }

        private List<string> createMockPosts(bool i_IsPersonalPosts = true)
        {
            List<string> posts = new List<string>();

            if (i_IsPersonalPosts == true)
            {
                posts.Add("I have many friends");
                posts.Add("But none posted on my wall");
                posts.Add("So I have only mock data");
            }
            else
            {
                posts.Add("Friend1: Wow i did so much HW today XDXD");
                posts.Add("Friend2: Any body up for Pizza?");
                posts.Add("Friend3: I love dogs");
                posts.Add("Friend4: Argentina will win the world cup");
                posts.Add("Friend5: Happy to annonce that i just started a new role as SWE in Desig Patter inc");
            }

            return posts;
        }

        private List<string> createMockEvents()
        {
            return new List<string>
            {
                "Singing session in Tel Aviv at 2100","Dance performance in Herzilia at 1900"
            };
        }

        private List<string> createMockFriends()
        {
            return new List<string>
            {
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides", "Desig Patter", "Avi Ron", "Imba Atid"
            };
        }

        private void fetchAlbums()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    foreach (Album album in m_LoggedInUser.Albums)
                    {
                        Albums.Items.Add(album);
                    }

                    if (Albums.Items.Count == 0)
                    {
                        MessageBox.Show(@"It looks like you don't have any albums");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(@"It looks like we encountered an issue with fetching your albums");
                }
            }));
        }

        private void buttonEvents_Click(object sender, EventArgs e)
        {
            new Thread(fetchEvents).Start();
        }

        private void buttonAlbums_Click(object sender, EventArgs e)
        {
            groupBoxAlbums1.Visible = true;
            groupBoxAlbums2.Visible = false;

            new Thread(fetchAlbums).Start();
            new Thread(showAlbumsCoverPicture).Start();
        }

        private void showAlbumsCoverPicture()
        {
            this.Invoke(new Action(() =>
            {
                Random randomNumber = new Random();
                int i = 0;

                if (m_LoggedInUser.Albums.Count > 0)
                {
                    foreach (Album album in m_LoggedInUser.Albums.OrderBy(i_AlbumRandom => randomNumber.Next()).Take(5))
                    {
                        m_AlbumsPictureBox[i].LoadAsync(album.PictureAlbumURL);
                        m_AlbumsLabels[i].Text = album.Name;
                        i++;
                    }
                }
            }));
        }

        private void displayMemoriesPicture(Object source, ElapsedEventArgs e)
        {
            Random randomNumber = new Random();
            if (m_LoggedInUser.Albums.Count > 0)
            {
                foreach (Album album in m_LoggedInUser.Albums.OrderBy(i_AlbumRandom => randomNumber.Next()).Take(1))
                {
                    foreach (Photo photo in album.Photos.OrderBy(i_PhotoRandom => randomNumber.Next()).Take(1))
                    {
                        pictureBoxMemories.LoadAsync(photo.ThumbURL);
                    }
                }
            }
        }

        private void fetchEvents()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    foreach (Event userEvents in m_LoggedInUser.Events)
                    {
                        Events.Items.Add(userEvents);
                    }

                    if (Events.Items.Count == 0)
                    {
                        MessageBox.Show(@"We couldn't find any events for you, here is some mock data");
                        insertMockEvents();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show(@"It looks like we encountered an issue with fetching your Events");
                }
            }));
        }

        private void buttonGroups_Click(object sender, EventArgs e)
        {
            buttonGroups.Visible = false;
            labelGroups.Visible = true;

            new Thread(getGroups).Start();
        }

        private void buttonTransformPicture_Click(object sender, EventArgs e)
        {
            toonifyPicture();
        }

        private void getGroups()
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    foreach (Group group in m_LoggedInUser.Groups)
                    {
                        Groups.Items.Add(group);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (Groups.Items.Count == 0)
                {
                    MessageBox.Show(@"Sorry but we didn't find any groups for you");
                }
            }));
        }

        private void toonifyPicture()
        {
            string localImageLocation = @"C:\localPicture.jpg";
            WebClient webClient = new WebClient();

            try
            {
                webClient.DownloadFile(m_LoggedInUser.PictureNormalURL, localImageLocation);
                getResponseOfToonifyApi(localImageLocation);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Sorry but our AI API model couldn't toonify your photo, here is a mock photo");
                toonifyMockPicture();
            }
            finally
            {
                webClient.Dispose();
            }
        }

        private string getLocationOfMockPhoto()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string fileLocation = Path.Combine(currentDirectory, @"..\..\..\Resources\mockPhoto.jpg");
            return Path.GetFullPath(fileLocation);
        }

        private void toonifyMockPicture()
        {
            string locationOfMockPhoto = getLocationOfMockPhoto();

            getResponseOfToonifyApi(locationOfMockPhoto, true);
        }

        private void getResponseOfToonifyApi(string i_LocalImageLocation, bool i_IsMock = false)
        {
            DeepAI_API apiKeyHolder = new DeepAI_API(apiKey: "quickstart-QUdJIGlzIGNvbWluZy4uLi4K");
            StandardApiResponse response = apiKeyHolder.callStandardApi("toonify", new { image = File.OpenRead(i_LocalImageLocation) });

            if (i_IsMock)
            {
                pictureBoxBefore.BackgroundImage = new Bitmap(i_LocalImageLocation);
            }
            else
            {
                pictureBoxBefore.LoadAsync(m_LoggedInUser.PictureNormalURL);
            }

            pictureBoxAfter.LoadAsync(response.output_url);
        }

        private void startGame()
        {
            m_FourCelebrities = m_CurrentGame.PlayGame();
            Random random = new Random();
            int randomNumberToPlaceAnswer = random.Next(4);

            switch (randomNumberToPlaceAnswer)
            {
                case 0:
                    buttonAnswer1.Text = m_FourCelebrities[3];
                    break;
                case 1:
                    buttonAnswer2.Text = m_FourCelebrities[3];
                    break;
                case 2:
                    buttonAnswer3.Text = m_FourCelebrities[3];
                    break;
                case 3:
                    buttonAnswer4.Text = m_FourCelebrities[3];
                    break;
            }

            int currentCelebrityCounterForList = 0;

            for (int buttonForInput = 0; buttonForInput < m_FourCelebrities.Count; buttonForInput++)
            {
                if (buttonForInput == randomNumberToPlaceAnswer)
                {
                    continue;
                }
                else
                {
                    switch (buttonForInput)
                    {
                        case 0:
                            buttonAnswer1.Text = m_FourCelebrities[currentCelebrityCounterForList];
                            break;
                        case 1:
                            buttonAnswer2.Text = m_FourCelebrities[currentCelebrityCounterForList];
                            break;
                        case 2:
                            buttonAnswer3.Text = m_FourCelebrities[currentCelebrityCounterForList];
                            break;
                        case 3:
                            buttonAnswer4.Text = m_FourCelebrities[currentCelebrityCounterForList];
                            break;
                    }

                    currentCelebrityCounterForList += 1;
                }
            }
        }

        private string getUserBirthMonth()
        {
            string birthDay = m_LoggedInUser.Birthday;

            return birthDay[0] == '0' ? birthDay[1].ToString() : (birthDay[0] + birthDay[1]).ToString();
        }

        private void buttonPlayGame_Click(object sender, EventArgs e)
        {
            startGame();

            foreach (Button button in m_GameAnswerButtons)
            {
                button.Visible = true;
            }
        }

        private void buttonAnswer1_Click(object sender, EventArgs e)
        {
            showResults(buttonAnswer1);
        }

        private void buttonAnswer2_Click(object sender, EventArgs e)
        {
            showResults(buttonAnswer2);
        }

        private void buttonAnswer3_Click(object sender, EventArgs e)
        {
            showResults(buttonAnswer3);
        }

        private void buttonAnswer4_Click(object sender, EventArgs e)
        {
            showResults(buttonAnswer4);
        }

        private void showResults(Button i_Button)
        {
            m_GameResults = GameResults.CreateOrGetGameResults();
            if (i_Button.Text == m_FourCelebrities[3])
            {
                i_Button.BackColor = Color.Green;
                m_GameResults.UpdateGameResults(i_WinningRound: true);
                labelNumberOfWins.Text = m_GameResults.GetGameResultsWins().ToString();
                groupBoxMessageNewGame.Visible = true;

            }
            else
            {
                i_Button.BackColor = Color.Red;
                m_GameResults.UpdateGameResults(i_WinningRound: false);
                labelNumberOfLoses.Text = m_GameResults.GetGameResultsLoses().ToString();
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            startGame();
            foreach (Button button in m_GameAnswerButtons)
            {
                button.BackColor = Color.White;
            }

            groupBoxMessageNewGame.Visible = false;
        }

        private void buttonShowLeaderBoard_Click(object sender, EventArgs e)
        {
            r_FormLeaderBoard.ShowDialog();
        }

        private void buttonGetLikedPosts_Click(object sender, EventArgs e)
        {
            FilterStrategy filter = new FilterStrategy();
            filter.SetSelectionStrategy(new MoreThanTenLikesFilter());
            Thread thread = new Thread(() => fetchFilteredPosts(filter));
            thread.Start();
        }

        private void buttonGetLastMonth_Click(object sender, EventArgs e)
        {
            FilterStrategy filter = new FilterStrategy();
            filter.SetSelectionStrategy(new LastMonthFilter());
            Thread thread = new Thread(() => fetchFilteredPosts(filter));
            thread.Start();
        }

        private void setControlsProperties()
        {
            foreach (Control control in m_Controls)
            {
                m_ControlProperties.Add(control, new ControlProperties(control));
            }
        }

        private void setControlsList()
        {
            foreach (Control control in this.Controls)
            {
                m_Controls.Add(control);
                addControlsToList(control);
            }
            m_Controls.Add(buttonPost);
            m_Controls.Add(buttonAlbums);
            m_Controls.Add(buttonGetAllPost);
            m_Controls.Add(buttonEvents);
            m_Controls.Add(buttonGetLastMonth);
            m_Controls.Add(buttonGetLikedPosts);
            m_Controls.Add(buttonViewLessAlbums);
            m_Controls.Add(buttonViewMoreAlbums);
        }

        private void addControlsToList(Control container)
        {
            foreach (Control c in container.Controls)
            {
                m_Controls.Add(c);

                if (c is GroupBox)
                {
                    addControlsToList(c);
                }
                else if (c is ListBox)
                {
                    addControlsToList(c);
                }
                else if (c is TabControl)
                {
                    addControlsToList(c);
                }
            }
        }

        private void setDarkModeDisplay(Button i_button)
        {
            i_button.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            i_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            i_button.ForeColor = System.Drawing.Color.White;
            i_button.Name = "ButtonDarkMode";
            i_button.Size = this.logoutButton.Size;
            i_button.Text = "DarkMode";
            i_button.Location = new Point(this.logoutButton.Left, this.logoutButton.Bottom - 5);
            i_button.ResumeLayout(false);
        }

        private void displayModeChange(string i_displayMode)
        {
            IDisplayCommand command = null;

            if (i_displayMode == "bright")
            {
                command = new BrightDisplayCommand(m_ControlProperties);
            }
            else if (i_displayMode == "dark")
            {
                command = new DarkDisplayCommand(m_ControlProperties);
            }
            if (command != null)
            {
                command.Execute();
            }
        }
    }
}