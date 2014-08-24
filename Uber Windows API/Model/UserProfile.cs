using System.Runtime.Serialization;

namespace Uwapi.Model
{
    /// <summary>
    /// The information about the Uber user that has authorized with the application.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// First name of the Uber user.
        /// </summary>
        [DataMember(Name = "first_name", IsRequired = true)]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the Uber user.
        /// </summary>
        [DataMember(Name = "last_name", IsRequired = true)]
        public string LastName { get; set; }

        /// <summary>
        /// Email address of the Uber user
        /// </summary>
        [DataMember(Name = "email", IsRequired = true)]
        public string Email { get; set; }

        /// <summary>
        /// Image URL of the Uber user.
        /// </summary>
        [DataMember(Name = "picture", IsRequired = true)]
        public string Picture { get; set; }

        /// <summary>
        /// Promo code of the Uber user.
        /// </summary>
        [DataMember(Name = "promo_code", IsRequired = true)]
        public string PromoCode { get; set; }
    }
}