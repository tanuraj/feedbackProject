using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Proj_Feedback
{
    public class DataInteraction
    {
        string connetionString;
        public DataInteraction()
        {
            connetionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ToString();

        }
        //select * from Tbl_Emotions

        public DataTable GetEmotionList()
        {
            string query = "select 0 as Emoji_Id,'' as ImgName,'Select Feedback' as Emotion union all select Emoji_Id,ImgName,Emotion from Tbl_Emotions";
            DataSet ds = SqlHelper.ExecuteDataset(connetionString, CommandType.Text, query);
            return ds.Tables[0];
        }


        public int InsertFeedback(FeedbackElement oFeed)
        {
            string query = "INSERT INTO TBL_FEEDBACK(Feed_DATETIME,NAME, MY_HAPPINESS_Emoji, MY_HAPPINESS_IMG, MY_HAPPINESS_REMARK, MY_PLAY_Emoji, MY_PLAY_IMG, MY_PLAY_REMARK" +
            ", TEAM_HAPPINESS_Emoji, TEAM_HAPPINESS_IMG, TEAM_HAPPINESS_REMARK, GAME_HAPPINESS_Emoji, GAME_HAPPINESS_IMG, GAME_HAPPINESS_REMARK" +
            ", MYHAPPINESSPIC,MYPLAYPIC,GAMEHAPPINESSPIC,TEAMHAPPINESSPIC)" +
            " VALUES(Sysdatetime(),'" + oFeed.NAME + "', '" + oFeed.MY_HAPPINESS_EMOTION + "', '" + oFeed.MY_HAPPINESS_IMGNAME + "', '" + oFeed.MY_HAPPINESS_REMARK + "', '" + oFeed.MY_PLAY_EMOTION + "', '" + oFeed.MY_PLAY_IMGNAME + "', '" + oFeed.MY_PLAY_REMARK + "' " +
            ", '" + oFeed.TEAM_HAPPINESS_EMOTION + "', '" + oFeed.TEAM_HAPPINESS_IMGNAME + "', '" + oFeed.TEAM_HAPPINESS_REMARK + "', '" + oFeed.GAME_HAPPINESS_EMOTION + "', '" + oFeed.GAME_HAPPINESS_IMGNAME + "', '" + oFeed.GAME_HAPPINESS_REMARK + "'" +
            ", cast('" + oFeed.MyHappyIMG + "' as varbinary(max)), cast('" + oFeed.MyPlayIMG + "' as varbinary(max)) ,cast('" + oFeed.GameIMG + "' as varbinary(max)), cast('" + oFeed.TeamIMG + "' as varbinary(max)))";
            int res = SqlHelper.ExecuteNonQuery(connetionString, CommandType.Text, query);
            return res;
        }

        public DataTable GetFeedbackDetail()
        {
            string query = "SELECT FEED_DATETIME,NAME, MY_HAPPINESS_Emoji, MY_HAPPINESS_IMG, MY_HAPPINESS_REMARK" +
                ", MY_PLAY_Emoji, MY_PLAY_IMG, MY_PLAY_REMARK, TEAM_HAPPINESS_Emoji, TEAM_HAPPINESS_IMG, TEAM_HAPPINESS_REMARK" +
                ", GAME_HAPPINESS_Emoji, GAME_HAPPINESS_IMG, GAME_HAPPINESS_REMARK  FROM TBL_FEEDBACK";
            DataSet ds = SqlHelper.ExecuteDataset(connetionString, CommandType.Text, query);
            return ds.Tables[0];
        }
    }

    public class FeedbackElement
    {

        public string NAME { get; set; }
        public string MY_HAPPINESS_EMOTION { get; set; }
        public string MY_HAPPINESS_IMGNAME { get; set; }
        public byte[] MyHappyIMG { get; set; }
        public string MY_HAPPINESS_REMARK { get; set; }

        public string MY_PLAY_EMOTION { get; set; }
        public string MY_PLAY_IMGNAME { get; set; }
        public byte[] MyPlayIMG { get; set; }
        public string MY_PLAY_REMARK { get; set; }

        public string TEAM_HAPPINESS_EMOTION { get; set; }
        public string TEAM_HAPPINESS_IMGNAME { get; set; }
        public byte[] TeamIMG { get; set; }
        public string TEAM_HAPPINESS_REMARK { get; set; }

        public string GAME_HAPPINESS_EMOTION { get; set; }
        public string GAME_HAPPINESS_IMGNAME { get; set; }
        public byte[] GameIMG { get; set; }
        public string GAME_HAPPINESS_REMARK { get; set; }
    }
}