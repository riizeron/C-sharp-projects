using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace First
{
    [DataContract]
    public class Section
    {
        [DataMember]
        public static List<Section> sections = new List<Section>();
        [DataMember]
        public List<Section> UnderSections { set; get; } = new List<Section>();
        [DataMember]
        public List<Product> Products { set; get; } = new List<Product>();
        [DataMember]
        public Section Parent { get; set; }
        [DataMember]
        string name;
        [DataMember]
        public string Path{ get; set; }
        /// <summary>
        /// Пустой конструктор для использования Json сериаизации которой в итоге нету.
        /// </summary>
        public Section()
        {

        }
        public Section(string name, Section parent)
        {
            this.Parent = parent;
            Name = name;
            sections.Add(this);
            Path = Parent==null?Name:Parent.Path+"/"+Name;
        }
        public string Name
        {
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Имя не может быть пустым");
                }
                if (Parent != null)
                {
                    foreach (Section sec in Parent.UnderSections)
                    {
                        if (value == sec.Name)
                        {
                            throw new ArgumentException("Подаздел с таким именем уже существует в этом разделе!");
                        }
                    }
                }
                name = value;
            }
            get
            {
                return name;
            }
        }
    }
}
