using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BasicFacebookFeatures
{
    public static class StaticFormFactory
    {
        public static Form CreateFormFactory(string i_Type, List<string> i_optionalParameters = null)
        {
            Form generatedForm = new Form();

            if (Enum.TryParse(i_Type, true, out FormTypeEnum.eFormTypeEnum o_formType))
            {
                try
                {
                    switch (o_formType)
                    {
                        case FormTypeEnum.eFormTypeEnum.FormMain:
                            generatedForm = new FormMain();
                            break;
                        case FormTypeEnum.eFormTypeEnum.FormLogin:
                            generatedForm = new FormLogin();
                            break;
                        case FormTypeEnum.eFormTypeEnum.FormLeaderBoard:
                            generatedForm = new FormLeaderBoard(i_UserNameEmail: i_optionalParameters[0], i_UserProfilePictureUrl: i_optionalParameters[1]);
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show(@"Some error occurred in the factory, returning general form");
                }
            }
            else
            {
                MessageBox.Show(@"Looks like your form type is unsupported by the factory, returning general form");
            }

            return generatedForm;
        }
    }
}