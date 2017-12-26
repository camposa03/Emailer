namespace Emailer.Services
{
    /// <summary>
    /// Container class to hold email credentials
    /// </summary>
    public class EmailSettings
    {
        /// <summary>
        /// The username of the e-mail account
        /// </summary>
        /// <returns></returns>
        public string Username { get; set; }
        /// <summary>
        /// The password of the e-mail account
        /// </summary>
        /// <returns></returns>
        public string Password { get; set; }

        /// <summary>
        /// The e-mail address of the sender
        /// </summary>
        /// <returns></returns>
        public string From { get; set; }    

        /// <summary>
        /// The e-mail address of the recipient
        /// </summary>
        /// <returns></returns>
        public string To { get; set; }                 
    }
}