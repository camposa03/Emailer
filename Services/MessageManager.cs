using System;
using System.Collections.Generic;

namespace Emailer.Services
{
    /// <summary>
    /// Determines who to send the e-mail message to, depending on the store
    /// </summary>
    public static class MessageManager
    {
        private const string Alameda = "Alameda";
        private const string Americas = "Americas";
        private const string Carolina = "Carolina";
        private const string Horizon = "Horizon";
        private const string JoeBattle = "JoeBattle";
        private const string NorthLoop = "NorthLoop";    
        private const string NorthMesa = "NorthMesa";
        private static Dictionary<string, string> emailMapping = new Dictionary<string, string>()
        {
            [Alameda] = "alameda.oasistires@gmail.com",
            [Americas] = "americas.oasistires@gmail.com",
            [Carolina] = "carolina.oasistires@gmail.com",
            [Horizon] = "horizon.oasistires@gmail.com",
            [JoeBattle] = "joebattle.oasistires@gmail.com",
            [NorthLoop] = "nloop.oasistires@gmail.com",
            [NorthMesa] = "mesa.oasistires@gmail.com"
        };
        
        /// <summary>
        /// Determines the e-mail address to send to, depending on the store
        /// </summary>
        /// <param name="storeName">The name of the store.</param>
        /// <returns>The e-mail address of the store</returns>
        public static string EmailAddress(string storeName)
        {
            var canGetValue = emailMapping.TryGetValue(storeName, out string emailRecipient);

            if (canGetValue) 
            {
                return emailRecipient;
            }
            return string.Empty;
            
        }

        /// <summary>
        /// Maps the unique identifier of an Oasis store to its string value
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public static string toStoreName(string storeId)
        {
            if (storeId == null) throw new ArgumentNullException(nameof(storeId));
            var comparer = StringComparison.InvariantCultureIgnoreCase;
            var storeName = string.Empty;

            if (storeId.Trim().Equals("15254", comparer))
            {
                storeName = Alameda;
            }

            if (storeId.Trim().Equals("15253", comparer))
            {
                storeName = NorthLoop;
            }

            if (storeId.Trim().Equals("10709", comparer))
            {
                storeName = Horizon;
            }

            if (storeId.Trim().Equals("10710", comparer))
            {
                storeName = Alameda;
            }

            if (storeId.Trim().Equals("15291", comparer))
            {
                storeName = JoeBattle;
            }

            if (storeId.Trim().Equals("106115", comparer))
            {
                storeName = Carolina;
            }

            return storeName;
        }
    }
}