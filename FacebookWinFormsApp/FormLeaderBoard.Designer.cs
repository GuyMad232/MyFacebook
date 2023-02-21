
namespace BasicFacebookFeatures
{
    partial class FormLeaderBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.PictureBox pictureBoxPodium;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLeaderBoard));
            this.labelFirstPlace = new System.Windows.Forms.Label();
            this.labelSecondPlace = new System.Windows.Forms.Label();
            this.labelThirdPlace = new System.Windows.Forms.Label();
            this.checkBoxUpdateScore = new System.Windows.Forms.CheckBox();
            this.labelNumberOfWins = new System.Windows.Forms.Label();
            this.labelWinsTitle = new System.Windows.Forms.Label();
            this.labelFirstNumWins = new System.Windows.Forms.Label();
            this.labelSecondNumWins = new System.Windows.Forms.Label();
            this.labelThirdNumWins = new System.Windows.Forms.Label();
            this.pictureBoxProfilePicturePodium = new System.Windows.Forms.PictureBox();
            pictureBoxPodium = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBoxPodium)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicturePodium)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPodium
            // 
            pictureBoxPodium.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxPodium.BackgroundImage")));
            pictureBoxPodium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxPodium.Location = new System.Drawing.Point(-1, -1);
            pictureBoxPodium.Name = "pictureBoxPodium";
            pictureBoxPodium.Size = new System.Drawing.Size(938, 608);
            pictureBoxPodium.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxPodium.TabIndex = 0;
            pictureBoxPodium.TabStop = false;
            // 
            // labelFirstPlace
            // 
            this.labelFirstPlace.AutoSize = true;
            this.labelFirstPlace.BackColor = System.Drawing.Color.Transparent;
            this.labelFirstPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFirstPlace.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelFirstPlace.Location = new System.Drawing.Point(311, 35);
            this.labelFirstPlace.Name = "labelFirstPlace";
            this.labelFirstPlace.Size = new System.Drawing.Size(65, 29);
            this.labelFirstPlace.TabIndex = 1;
            this.labelFirstPlace.Text = "First";
            this.labelFirstPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSecondPlace
            // 
            this.labelSecondPlace.AutoSize = true;
            this.labelSecondPlace.BackColor = System.Drawing.Color.Transparent;
            this.labelSecondPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelSecondPlace.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelSecondPlace.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSecondPlace.Location = new System.Drawing.Point(-1, 121);
            this.labelSecondPlace.Name = "labelSecondPlace";
            this.labelSecondPlace.Size = new System.Drawing.Size(102, 29);
            this.labelSecondPlace.TabIndex = 2;
            this.labelSecondPlace.Text = "Second";
            // 
            // labelThirdPlace
            // 
            this.labelThirdPlace.AutoSize = true;
            this.labelThirdPlace.BackColor = System.Drawing.Color.Transparent;
            this.labelThirdPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelThirdPlace.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelThirdPlace.Location = new System.Drawing.Point(644, 179);
            this.labelThirdPlace.Name = "labelThirdPlace";
            this.labelThirdPlace.Size = new System.Drawing.Size(75, 29);
            this.labelThirdPlace.TabIndex = 3;
            this.labelThirdPlace.Text = "Third";
            this.labelThirdPlace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxUpdateScore
            // 
            this.checkBoxUpdateScore.AutoSize = true;
            this.checkBoxUpdateScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.checkBoxUpdateScore.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkBoxUpdateScore.Location = new System.Drawing.Point(71, 512);
            this.checkBoxUpdateScore.Name = "checkBoxUpdateScore";
            this.checkBoxUpdateScore.Size = new System.Drawing.Size(193, 62);
            this.checkBoxUpdateScore.TabIndex = 4;
            this.checkBoxUpdateScore.Text = "Update my \r\ncorrent score";
            this.checkBoxUpdateScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxUpdateScore.UseVisualStyleBackColor = true;
            this.checkBoxUpdateScore.CheckedChanged += new System.EventHandler(this.checkBoxUpdateScore_CheckedChanged);
            // 
            // labelNumberOfWins
            // 
            this.labelNumberOfWins.AutoSize = true;
            this.labelNumberOfWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumberOfWins.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelNumberOfWins.Location = new System.Drawing.Point(852, 528);
            this.labelNumberOfWins.Name = "labelNumberOfWins";
            this.labelNumberOfWins.Size = new System.Drawing.Size(27, 29);
            this.labelNumberOfWins.TabIndex = 9;
            this.labelNumberOfWins.Text = "0";
            this.labelNumberOfWins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelWinsTitle
            // 
            this.labelWinsTitle.AutoSize = true;
            this.labelWinsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWinsTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelWinsTitle.Location = new System.Drawing.Point(668, 528);
            this.labelWinsTitle.Name = "labelWinsTitle";
            this.labelWinsTitle.Size = new System.Drawing.Size(166, 29);
            this.labelWinsTitle.TabIndex = 8;
            this.labelWinsTitle.Text = "Current wins:";
            // 
            // labelFirstNumWins
            // 
            this.labelFirstNumWins.AutoSize = true;
            this.labelFirstNumWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFirstNumWins.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelFirstNumWins.Location = new System.Drawing.Point(463, 76);
            this.labelFirstNumWins.Name = "labelFirstNumWins";
            this.labelFirstNumWins.Size = new System.Drawing.Size(27, 29);
            this.labelFirstNumWins.TabIndex = 10;
            this.labelFirstNumWins.Text = "0";
            this.labelFirstNumWins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelSecondNumWins
            // 
            this.labelSecondNumWins.AutoSize = true;
            this.labelSecondNumWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSecondNumWins.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelSecondNumWins.Location = new System.Drawing.Point(187, 170);
            this.labelSecondNumWins.Name = "labelSecondNumWins";
            this.labelSecondNumWins.Size = new System.Drawing.Size(27, 29);
            this.labelSecondNumWins.TabIndex = 11;
            this.labelSecondNumWins.Text = "0";
            this.labelSecondNumWins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelThirdNumWins
            // 
            this.labelThirdNumWins.AutoSize = true;
            this.labelThirdNumWins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThirdNumWins.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelThirdNumWins.Location = new System.Drawing.Point(727, 211);
            this.labelThirdNumWins.Name = "labelThirdNumWins";
            this.labelThirdNumWins.Size = new System.Drawing.Size(27, 29);
            this.labelThirdNumWins.TabIndex = 12;
            this.labelThirdNumWins.Text = "0";
            this.labelThirdNumWins.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBoxProfilePicturePodium
            // 
            this.pictureBoxProfilePicturePodium.BackColor = System.Drawing.Color.MediumBlue;
            this.pictureBoxProfilePicturePodium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxProfilePicturePodium.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxProfilePicturePodium.Location = new System.Drawing.Point(802, -1);
            this.pictureBoxProfilePicturePodium.Name = "pictureBoxProfilePicturePodium";
            this.pictureBoxProfilePicturePodium.Size = new System.Drawing.Size(135, 106);
            this.pictureBoxProfilePicturePodium.TabIndex = 13;
            this.pictureBoxProfilePicturePodium.TabStop = false;
            // 
            // FormLeaderBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(937, 605);
            this.Controls.Add(this.pictureBoxProfilePicturePodium);
            this.Controls.Add(this.labelThirdNumWins);
            this.Controls.Add(this.labelSecondNumWins);
            this.Controls.Add(this.labelFirstNumWins);
            this.Controls.Add(this.labelNumberOfWins);
            this.Controls.Add(this.labelWinsTitle);
            this.Controls.Add(this.checkBoxUpdateScore);
            this.Controls.Add(this.labelThirdPlace);
            this.Controls.Add(this.labelSecondPlace);
            this.Controls.Add(this.labelFirstPlace);
            this.Controls.Add(pictureBoxPodium);
            this.Name = "FormLeaderBoard";
            this.Text = "Leader Board";
            ((System.ComponentModel.ISupportInitialize)(pictureBoxPodium)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfilePicturePodium)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFirstPlace;
        private System.Windows.Forms.Label labelSecondPlace;
        private System.Windows.Forms.Label labelThirdPlace;
        private System.Windows.Forms.CheckBox checkBoxUpdateScore;
        private System.Windows.Forms.Label labelNumberOfWins;
        private System.Windows.Forms.Label labelWinsTitle;
        private System.Windows.Forms.Label labelFirstNumWins;
        private System.Windows.Forms.Label labelSecondNumWins;
        private System.Windows.Forms.Label labelThirdNumWins;
        private System.Windows.Forms.PictureBox pictureBoxProfilePicturePodium;
    }
}