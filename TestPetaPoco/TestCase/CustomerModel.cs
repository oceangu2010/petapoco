using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPetaPoco.TestCase
{
    [Serializable]
    public partial class Customers
    {
        public Customers()
        { }
        #region Model
        private int _pkid;
        private string _code;
        private string _description;
        private int? _customertypeid;
        private string _providertypes;
        private string _bannername;
        private string _address;
        private string _city;
        private string _state;
        private string _zipcode;
        private string _dataprefix = "Default_";
        private string _bankname;
        private string _bankaccountname;
        private string _bankaccountnumber;
        private string _bankroutingnumber;
        private string _authorizenetapiloginid;
        private string _authorizenettransactionkey;
        private string _emailaddress;
        private string _selfpayonlinedocidsuffix = "0000100001";
        private string _companyidentification;
        private string _companyentrydescription;
        /// <summary>
        /// 
        /// </summary>
        public int PKId
        {
            set { _pkid = value; }
            get { return _pkid; }
        }
        /// <summary>
        /// Provider code indicated by 4 nchar
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// Provider description
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CustomerTypeId
        {
            set { _customertypeid = value; }
            get { return _customertypeid; }
        }
        /// <summary>
        /// provider types
        /// </summary>
        public string ProviderTypes
        {
            set { _providertypes = value; }
            get { return _providertypes; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BannerName
        {
            set { _bannername = value; }
            get { return _bannername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ZipCode
        {
            set { _zipcode = value; }
            get { return _zipcode; }
        }
        /// <summary>
        /// Data prefix, such as "Default_", "CSSA_", "NAOX_"... Default value is "Default_"
        /// </summary>
        public string DataPrefix
        {
            set { _dataprefix = value; }
            get { return _dataprefix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountName
        {
            set { _bankaccountname = value; }
            get { return _bankaccountname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankAccountNumber
        {
            set { _bankaccountnumber = value; }
            get { return _bankaccountnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BankRoutingNumber
        {
            set { _bankroutingnumber = value; }
            get { return _bankroutingnumber; }
        }
        /// <summary>
        /// Authorize.Net API login id
        /// </summary>
        public string AuthorizeNetAPILoginId
        {
            set { _authorizenetapiloginid = value; }
            get { return _authorizenetapiloginid; }
        }
        /// <summary>
        /// Authorize.Net transaction key
        /// </summary>
        public string AuthorizeNetTransactionKey
        {
            set { _authorizenettransactionkey = value; }
            get { return _authorizenettransactionkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAddress
        {
            set { _emailaddress = value; }
            get { return _emailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SelfpayOnlineDocIdSuffix
        {
            set { _selfpayonlinedocidsuffix = value; }
            get { return _selfpayonlinedocidsuffix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyIdentification
        {
            set { _companyidentification = value; }
            get { return _companyidentification; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CompanyEntryDescription
        {
            set { _companyentrydescription = value; }
            get { return _companyentrydescription; }
        }
        #endregion Model

    }

    [Serializable]
    public partial class CustomerUsers
    {
        public CustomerUsers()
        { }
        #region Model
        private int _pkid;
        private int _customerid;
        private string _username;
        private string _password;
        private string _passwordwithhash;
        private DateTime _createddt = DateTime.Now;
        private DateTime? _lastlogindt;
        private string _lastloginip;
        private bool _sex;
        private DateTime? _dob;
        private string _emailaddress;
        private string _department;
        private string _position;
        private bool _isadministrator = false;
        private bool _isdisabled = false;
        private string _firstname;
        private string _middlename;
        private string _lastname;
        /// <summary>
        /// 
        /// </summary>
        public int PKId
        {
            set { _pkid = value; }
            get { return _pkid; }
        }
        /// <summary>
        /// Customer id
        /// </summary>
        public int CustomerId
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// User name
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PasswordWithHash
        {
            set { _passwordwithhash = value; }
            get { return _passwordwithhash; }
        }
        /// <summary>
        /// Created date time
        /// </summary>
        public DateTime CreatedDt
        {
            set { _createddt = value; }
            get { return _createddt; }
        }
        /// <summary>
        /// Last login date time
        /// </summary>
        public DateTime? LastLoginDt
        {
            set { _lastlogindt = value; }
            get { return _lastlogindt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DOB
        {
            set { _dob = value; }
            get { return _dob; }
        }
        /// <summary>
        /// Bank user email address
        /// </summary>
        public string EmailAddress
        {
            set { _emailaddress = value; }
            get { return _emailaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Position
        {
            set { _position = value; }
            get { return _position; }
        }
        /// <summary>
        /// Is administrator
        /// </summary>
        public bool IsAdministrator
        {
            set { _isadministrator = value; }
            get { return _isadministrator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDisabled
        {
            set { _isdisabled = value; }
            get { return _isdisabled; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FirstName
        {
            set { _firstname = value; }
            get { return _firstname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MiddleName
        {
            set { _middlename = value; }
            get { return _middlename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastName
        {
            set { _lastname = value; }
            get { return _lastname; }
        }
        #endregion Model

    }

    [Serializable]
    public class CustomerUser
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
    
    }
}
