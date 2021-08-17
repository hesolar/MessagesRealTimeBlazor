using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensajes.Pages {
    public class Index2Base: ComponentBase {

        [Parameter] public  IMessageQuery query { get; set; }
    public String newMsg = "";
    public List<String> Mensajes = new();

    public void sendMessage() {
        query.AddMessage(newMsg);
        Mensajes = query.RetrieveAll();
        InvokeAsync(StateHasChanged);
    }

    protected override void OnParametersSet() {

        query.PropertyChanged += ( e,f ) => InvokeAsync(() => StateHasChanged());
        Mensajes = query.RetrieveAll();
    }


    }
}
