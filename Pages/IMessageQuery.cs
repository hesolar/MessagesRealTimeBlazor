using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mensajes.Pages {
    public class IMessageQuery :INotifyPropertyChanged {
        private StreamReader reader ;
        private StreamWriter writer;
        public event PropertyChangedEventHandler PropertyChanged;
        public String FileName { get; set; }
        public List<String> Messages { get; set; }


        public IMessageQuery(String FileName ) {
            
            this.FileName = FileName;
            Messages = RetrieveAll();
            
        }
     

        public List<String> AddMessage(String s ) {
            writer = new(FileName,append:true);
            writer.Write(DateTime.Now.TimeOfDay + ":" + s+" ");
            writer.Close();
            
            return RetrieveAll();
        }

        public List<String> RetrieveAll() {
           
            reader = new(FileName);
            
            var x = reader.ReadToEnd();
            Messages = x.Split(" ").ToList();
            reader.Close();
            if( Messages.Count <= 1 ) return new();
            Messages.RemoveAt(Messages.Count - 1);
            return this.Messages;
        }

    }
}
