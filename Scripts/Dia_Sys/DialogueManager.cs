using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System;

public class DialogueManager {
  public XDocument xmlDoc ;
  public List<Dialogue> list;


  public DialogueManager() {
    xmlDoc = XDocument.Load(Application.dataPath + "/drama.xml") ;
  } // DialogueManager()



  // 讀取xml檔將資料轉成Dialogue Object
  public List<Dialogue> ReadXml( string DiaName ) {
    XElement xe = xmlDoc.Root.Element(DiaName);
    int DiaID = Convert.ToInt32(xe.Element("DiaID").Value);
    int TaskID = Convert.ToInt32(xe.Element("TaskID").Value);
    IEnumerable<XElement> person = xe.Elements("Name");
    IEnumerable<XElement> contents = xe.Elements("Words");
    List<Dialogue> dia = new List<Dialogue>() ;

    int i = 0;
    foreach ( XElement name in person ) {
        Dialogue d = new Dialogue();
        d.DiaID = DiaID ;
        d.TaskID = TaskID ;
        d.name = name.Value ;
        d.str = contents.ElementAt<XElement>(i).Value ;
        dia.Add( d ) ;
        i++;
    } // foreach

    return dia ;
  } // ReadXml()



  // 顯示下一句對話
  public void NextDia(List<Dialogue> d, GameObject frame, GameObject f_name) {
    Text t = frame.GetComponentInChildren<Text>();
    Text n = f_name.GetComponentInChildren<Text>();
    n.text = d[0].name;
    t.text = d[0].str.Replace("\\n","\n");
    if (d.Count == 1) d.Clear();
    else d.RemoveAt(0);
  } // NextDia()

} // class DialogueManager