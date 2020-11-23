using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proj_Feedback
{
    public partial class Feedback_Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnSave.Enabled = true;
                LblError.Text = string.Empty;
                data();
                Imagetitlebind();
            }
        }

        public void data()
        {
            DataInteraction odata = new DataInteraction();

            DataTable dt = odata.GetEmotionList();


            ddlMyHappinessImg.DataSource = dt;
            ddlMyHappinessImg.DataTextField = "Emotion";
            ddlMyHappinessImg.DataValueField = "ImgName";
            ddlMyHappinessImg.DataBind();

            ddlMyPlayImg.DataSource = dt;
            ddlMyPlayImg.DataTextField = "Emotion";
            ddlMyPlayImg.DataValueField = "ImgName";
            ddlMyPlayImg.DataBind();

            ddlTeamHappyImg.DataSource = dt;
            ddlTeamHappyImg.DataTextField = "Emotion";
            ddlTeamHappyImg.DataValueField = "ImgName";
            ddlTeamHappyImg.DataBind();

            ddlGameHappyImg.DataSource = dt;
            ddlGameHappyImg.DataTextField = "Emotion";
            ddlGameHappyImg.DataValueField = "ImgName";
            ddlGameHappyImg.DataBind();

        }
        protected void Imagetitlebind()
        {

            if (ddlMyHappinessImg != null)
            {
                foreach (ListItem li in ddlMyHappinessImg.Items)
                {
                    li.Attributes["title"] = li.Value; // Define the folder of image which is defined in the application.

                }
            }
            if (ddlMyPlayImg != null)
            {
                foreach (ListItem li in ddlMyPlayImg.Items)
                {
                    li.Attributes["title"] = li.Value; // Define the folder of image which is defined in the application.

                }
            }
            if (ddlTeamHappyImg != null)
            {
                foreach (ListItem li in ddlTeamHappyImg.Items)
                {
                    li.Attributes["title"] = li.Value; // Define the folder of image which is defined in the application.

                }
            }
            if (ddlGameHappyImg != null)
            {
                foreach (ListItem li in ddlGameHappyImg.Items)
                {
                    li.Attributes["title"] = li.Value; // Define the folder of image which is defined in the application.
                }
            }
        }
        //public DataTable GetDataForChart()
        //{
        //    DataTable _objdt = new DataTable();

        //    _objdt.Columns.Add("flag", typeof(string));
        //    _objdt.Columns.Add("name", typeof(string));

        //    _objdt.Columns.Add("LabelValue");
        //    var _objrow = _objdt.NewRow();
        //    _objrow["name"] = "India";
        //    _objrow["flag"] = "images/flag-of-India.png";

        //    _objdt.Rows.Add(_objrow);
        //    _objrow = _objdt.NewRow();
        //    _objrow["name"] = "Kuwait";
        //    _objrow["flag"] = "images/flag-of-Kuwait.png";
        //    _objdt.Rows.Add(_objrow);

        //    _objrow = _objdt.NewRow();
        //    _objrow["name"] = "Egypt";
        //    _objrow["flag"] = "images/flag-of-Egypt.png";
        //    _objdt.Rows.Add(_objrow);

        //    _objrow = _objdt.NewRow();
        //    _objrow["name"] = "Bangladesh";
        //    _objrow["flag"] = "images/flag-of-Bangladesh.png";
        //    _objdt.Rows.Add(_objrow);

        //    _objrow = _objdt.NewRow();
        //    _objrow["name"] = "Afghanistan";
        //    _objrow["flag"] = "images/flag-of-Afghanistan.png";
        //    _objdt.Rows.Add(_objrow);
        //    return _objdt;
        //}

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FeedbackElement oFeed = new FeedbackElement();
            string erMsg = validateFields();
            if (!string.IsNullOrEmpty(erMsg.Trim()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('" + erMsg.Trim() + "');", true);


               // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Notify", "alert('Notification : '"+erMsg.Trim()+"');", true);
                // LblError.Text = erMsg.Trim();
                //divError.InnerText = erMsg.Trim();
                return;
            }
            else
            {
                oFeed.NAME = txtName.Text;

                oFeed.MY_HAPPINESS_EMOTION = ddlMyHappinessImg.SelectedItem.Text;
                oFeed.MY_HAPPINESS_IMGNAME = ddlMyHappinessImg.SelectedItem.Value;
                oFeed.MY_HAPPINESS_REMARK = txtMyHappiness.Text;

                oFeed.MY_PLAY_EMOTION = ddlMyPlayImg.SelectedItem.Text;
                oFeed.MY_PLAY_IMGNAME = ddlMyPlayImg.SelectedItem.Value;
                oFeed.MY_PLAY_REMARK = txtMyPlay.Text;

                oFeed.GAME_HAPPINESS_EMOTION = ddlGameHappyImg.SelectedItem.Text;
                oFeed.GAME_HAPPINESS_IMGNAME = ddlGameHappyImg.SelectedItem.Value;
                oFeed.GAME_HAPPINESS_REMARK = txtGameHappiness.Text;


                oFeed.TEAM_HAPPINESS_EMOTION = ddlTeamHappyImg.SelectedItem.Text;
                oFeed.TEAM_HAPPINESS_IMGNAME = ddlTeamHappyImg.SelectedItem.Value;
                oFeed.TEAM_HAPPINESS_REMARK = txtTeamHappiness.Text;
                DataInteraction odal = new DataInteraction();
                int result = odal.InsertFeedback(oFeed);
                if (result == 1)
                {
                   //  LblError.Text = "Thanks for yor feedback";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Thanks for yor feedback');", true);

                    //  divError.InnerText = "Thanks for yor feedback";
                    btnSave.Enabled = false;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Alert", "alert('Oops! Something went wrong.');", true);
               //     LblError.Text = "  Oops! Something went wrong.";
                  //  divError.InnerText = "  Oops! Something went wrong.";
                    btnSave.Enabled = true;
                }

            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LblError.Text = string.Empty;
          //  divError.InnerText = string.Empty;
            txtName.Text = string.Empty;

            ddlMyHappinessImg.SelectedIndex = 0;
            ddlMyPlayImg.SelectedIndex = 0;
            ddlTeamHappyImg.SelectedIndex = 0;
            ddlGameHappyImg.SelectedIndex = 0;

            txtMyHappiness.Text = string.Empty;
            txtMyPlay.Text = string.Empty;

            txtTeamHappiness.Text = string.Empty;

            txtGameHappiness.Text = string.Empty;

        }

        private string validateFields()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                return "Name Required";
            }

            if (ddlMyHappinessImg.SelectedValue == "" || ddlMyHappinessImg.Text == "Select Feedback")
            {
                return "My Happiness Feedback Required";
            }
            if (string.IsNullOrEmpty(txtMyHappiness.Text.Trim()))
            {
                return "My Happiness Remark Required.";
            }

            if (ddlMyPlayImg.SelectedValue == "" || ddlMyPlayImg.Text == "Select Feedback")
            {
                return "My Play Feedback Required";
            }
            if (string.IsNullOrEmpty(txtMyPlay.Text.Trim()))
            {
                return "My Play Remark Required.";
            }

            if (ddlGameHappyImg.SelectedValue == "" || ddlGameHappyImg.Text == "Select Feedback")
            {
                return "Game Happiness Feedback Required";
            }
            if (string.IsNullOrEmpty(txtGameHappiness.Text.Trim()))
            {
                return "Game Happiness Remark Required.";
            }

            if (ddlTeamHappyImg.SelectedValue == "" || ddlTeamHappyImg.Text == "Select Feedback")
            {
                return "Team Happiness Feedback Required";
            }
            if (string.IsNullOrEmpty(txtTeamHappiness.Text.Trim()))
            {
                return "Team Happiness Remark Required.";
            }

            return string.Empty;
        }
    }
}