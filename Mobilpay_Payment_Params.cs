// Decompiled with JetBrains decompiler
// Type: MobilpayEncryptDecrypt.Mobilpay_Payment_Params
// Assembly: MobilpayEncryptDecrypt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E9668A4E-41EC-4174-9AFB-E80FB974BD68
// Assembly location: C:\Users\bogdan.hatis\Desktop\WebSite1\MobilpayEncryptDecrypt.dll

using System;
using System.Xml.Serialization;

namespace MobilpayEncryptDecrypt
{
  [Serializable]
  public class Mobilpay_Payment_Params
  {
    private string name;
    private string _value;

    [XmlElement("name")]
    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    [XmlElement("value")]
    public string Value
    {
      get
      {
        return this._value;
      }
      set
      {
        this._value = value;
      }
    }
  }
}
