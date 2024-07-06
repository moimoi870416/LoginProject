namespace LoginTest.Models
{
    /// <summary>
    /// 用戶的資料
    /// </summary>
    public class UserEntity
    {
        public string Account { get;set; }

        public string Password { get;set; }

        public Identity Identity { get;set; }
    }

    /// <summary>
    /// 會員身分
    /// </summary>
    public enum Identity
    {
        /// <summary>
        /// 系統管理員
        /// </summary>
        Admin = 0,

        /// <summary>
        /// 高級會員
        /// </summary>
        VIP = 10,

        /// <summary>
        /// 一般會員
        /// </summary>
        Regular = 100
    }
}
