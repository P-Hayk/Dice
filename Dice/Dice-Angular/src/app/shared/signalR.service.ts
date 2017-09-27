import { Injectable } from "@angular/core";
import { SignalR, ISignalRConnection } from "ng2-signalr";


@Injectable()
export class SignalRService {
    
   private connection: Promise<ISignalRConnection>;

    constructor(private _signalR: SignalR) {
       
        this.connection = this._signalR.connect()
            .then(c => {
               return  c;
             });
    }


    public get Connection() {

        return this.connection;
    }



}