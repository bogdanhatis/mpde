// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Error
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Error
  {
    private string code;
    private string error;

    [XmlAttribute("code")]
    public string Code
    {
      get
      {
        return this.code;
      }
      set
      {
        this.code = value;
      }
    }

    [XmlText]
    public string Message
    {
      get
      {
        return this.error;
      }
      set
      {
        this.error = value;
      }
    }
  }
}
