using System;
using System.Collections;
using System.Collections.Generic;

using Domain.Entity.Base;

namespace Domain.Entity
{
    public partial class Customer : BusinessBase<string>
    {
        #region Declarations

		private string _companyName = String.Empty;
		private string _contactName = null;
		private string _contactTitle = null;
		private string _address = null;
		private string _city = null;
		private string _region = null;
		private string _postalCode = null;
		private string _country = null;
		private string _phone = null;
		private string _fax = null;
		
		
		private IList<CustomerDemographic> _customerDemographics = new List<CustomerDemographic>();
		private IList<Order> _orders = new List<Order>();
		
		#endregion

        #region Constructors

        public Customer() { }

        #endregion

        #region Methods

        public override int GetHashCode()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            
            sb.Append(this.GetType().FullName);
			sb.Append(_companyName);
			sb.Append(_contactName);
			sb.Append(_contactTitle);
			sb.Append(_address);
			sb.Append(_city);
			sb.Append(_region);
			sb.Append(_postalCode);
			sb.Append(_country);
			sb.Append(_phone);
			sb.Append(_fax);

            return sb.ToString().GetHashCode();
        }

        #endregion

        #region Properties

		public virtual string CompanyName
        {
            get { return _companyName; }
			set
			{
				OnCompanyNameChanging();
				_companyName = value;
				OnCompanyNameChanged();
			}
        }
		partial void OnCompanyNameChanging();
		partial void OnCompanyNameChanged();
		
		public virtual string ContactName
        {
            get { return _contactName; }
			set
			{
				OnContactNameChanging();
				_contactName = value;
				OnContactNameChanged();
			}
        }
		partial void OnContactNameChanging();
		partial void OnContactNameChanged();
		
		public virtual string ContactTitle
        {
            get { return _contactTitle; }
			set
			{
				OnContactTitleChanging();
				_contactTitle = value;
				OnContactTitleChanged();
			}
        }
		partial void OnContactTitleChanging();
		partial void OnContactTitleChanged();
		
		public virtual string Address
        {
            get { return _address; }
			set
			{
				OnAddressChanging();
				_address = value;
				OnAddressChanged();
			}
        }
		partial void OnAddressChanging();
		partial void OnAddressChanged();
		
		public virtual string City
        {
            get { return _city; }
			set
			{
				OnCityChanging();
				_city = value;
				OnCityChanged();
			}
        }
		partial void OnCityChanging();
		partial void OnCityChanged();
		
		public virtual string Region
        {
            get { return _region; }
			set
			{
				OnRegionChanging();
				_region = value;
				OnRegionChanged();
			}
        }
		partial void OnRegionChanging();
		partial void OnRegionChanged();
		
		public virtual string PostalCode
        {
            get { return _postalCode; }
			set
			{
				OnPostalCodeChanging();
				_postalCode = value;
				OnPostalCodeChanged();
			}
        }
		partial void OnPostalCodeChanging();
		partial void OnPostalCodeChanged();
		
		public virtual string Country
        {
            get { return _country; }
			set
			{
				OnCountryChanging();
				_country = value;
				OnCountryChanged();
			}
        }
		partial void OnCountryChanging();
		partial void OnCountryChanged();
		
		public virtual string Phone
        {
            get { return _phone; }
			set
			{
				OnPhoneChanging();
				_phone = value;
				OnPhoneChanged();
			}
        }
		partial void OnPhoneChanging();
		partial void OnPhoneChanged();
		
		public virtual string Fax
        {
            get { return _fax; }
			set
			{
				OnFaxChanging();
				_fax = value;
				OnFaxChanged();
			}
        }
		partial void OnFaxChanging();
		partial void OnFaxChanged();
		
		public virtual IList<CustomerDemographic> CustomerDemographics
        {
            get { return _customerDemographics; }
            set
			{
				OnCustomerDemographicsChanging();
				_customerDemographics = value;
				OnCustomerDemographicsChanged();
			}
        }
		partial void OnCustomerDemographicsChanging();
		partial void OnCustomerDemographicsChanged();
		
		public virtual IList<Order> Orders
        {
            get { return _orders; }
            set
			{
				OnOrdersChanging();
				_orders = value;
				OnOrdersChanged();
			}
        }
		partial void OnOrdersChanging();
		partial void OnOrdersChanged();
		
        #endregion
    }
}
