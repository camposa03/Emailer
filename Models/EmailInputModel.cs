namespace Emailer.Models
{
    public class EmailInputModel
    {
        /// <summary>
        /// The body of the message as a serialized json string
        /// </summary>
        /// <returns></returns>
        public string CustomerInformation { get; set; }

        /// <summary>
        /// The customer's first name
        /// </summary>
        /// <returns></returns>
        public string CustomerFirstName { get; set; }
        /// <summary>
        /// The customer's last name
        /// </summary>
        /// <returns></returns>
        public string CustomerLastName { get;set; }

    }
}