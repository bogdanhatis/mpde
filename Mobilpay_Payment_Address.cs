// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Address
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Address
  {
    private string type;
    private string firstName;
    private string lastName;
    private string fiscalNumber;
    private string identityNumber;
    private string country;
    private string county;
    private string city;
    private string zipCode;
    private string address;
    private string email;
    private string mobilPhone;
    private string bank;
    private string iban;
    private string sameasbilling;

    [XmlAttribute("type")]
    public string Type
    {
      get
      {
        return this.type;
      }
      set
      {
        this.type = value;
      }
    }

    [XmlAttribute("sameasbilling")]
    public string Sameasbilling
    {
      get
      {
        return this.sameasbilling;
      }
      set
      {
        this.sameasbilling = value;
      }
    }

    [XmlElement("first_name")]
    public string FirstName
    {
      get
      {
        return this.firstName;
      }
      set
      {
        this.firstName = value;
      }
    }

    [XmlElement("last_name")]
    public string LastName
    {
      get
      {
        return this.lastName;
      }
      set
      {
        this.lastName = value;
      }
    }

    [XmlElement("fiscal_number")]
    public string FiscalNumber
    {
      get
      {
        return this.fiscalNumber;
      }
      set
      {
        this.fiscalNumber = value;
      }
    }

    [XmlElement("identity_number")]
    public string IdentityNumber
    {
      get
      {
        return this.identityNumber;
      }
      set
      {
        this.identityNumber = value;
      }
    }

    [XmlElement("country")]
    public string Country
    {
      get
      {
        return this.country;
      }
      set
      {
        this.country = value;
      }
    }

    [XmlElement("county")]
    public string County
    {
      get
      {
        return this.county;
      }
      set
      {
        this.county = value;
      }
    }

    [XmlElement("city")]
    public string City
    {
      get
      {
        return this.city;
      }
      set
      {
        this.city = value;
      }
    }

    [XmlElement("zip_code")]
    public string ZipCode
    {
      get
      {
        return this.zipCode;
      }
      set
      {
        this.zipCode = value;
      }
    }

    [XmlElement("address")]
    public string Address
    {
      get
      {
        return this.address;
      }
      set
      {
        this.address = value;
      }
    }

    [XmlElement("email")]
    public string Email
    {
      get
      {
        return this.email;
      }
      set
      {
        this.email = value;
      }
    }

    [XmlElement("mobile_phone")]
    public string MobilPhone
    {
      get
      {
        return this.mobilPhone;
      }
      set
      {
        this.mobilPhone = value;
      }
    }

    [XmlElement("bank")]
    public string Bank
    {
      get
      {
        return this.bank;
      }
      set
      {
        this.bank = value;
      }
    }

    [XmlElement("iban")]
    public string Iban
    {
      get
      {
        return this.iban;
      }
      set
      {
        this.iban = value;
      }
    }
  }
}
