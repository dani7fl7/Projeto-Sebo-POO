using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class Arquivo<Q> {

  public Q Abrir(string arquivo) {
    XmlSerializer xml = new XmlSerializer(typeof(Q));
    StreamReader f = new StreamReader(arquivo, Encoding.Default);
    Q obj = (Q) xml.Deserialize(f);
    f.Close();
    return obj;
  }

  public void Salvar(string arquivo, Q obj) {
    XmlSerializer xml = new XmlSerializer(typeof(Q));
    StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
    xml.Serialize(f, obj);
    f.Close();
  }

}