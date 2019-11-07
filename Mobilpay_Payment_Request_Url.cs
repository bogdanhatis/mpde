// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Request_Url
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Request_Url
  {
    private string confirmUrl;
    private string cancelUrl;
    private string returnUrl;

    [XmlElement("confirm")]
    public string ConfirmUrl
    {
      get
      {
        return this.confirmUrl;
      }
      set
      {
        this.confirmUrl = value;
      }
    }

    [XmlElement("return")]
    public string ReturnUrl
    {
      get
      {
        return this.returnUrl;
      }
      set
      {
        this.returnUrl = value;
      }
    }

    [XmlElement("cancel")]
    public string CancelUrl
    {
      get
      {
        return this.cancelUrl;
      }
      set
      {
        this.cancelUrl = value;
      }
    }
  }
}
