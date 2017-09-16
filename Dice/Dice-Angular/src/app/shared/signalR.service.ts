import { Injectable } from "@angular/core";
import { SignalR, ISignalRConnection } from "ng2-signalr";


@Injectable()
export class SignalRService {
   private connection: ISignalRConnection;

    constructor(private _signalR: SignalR) {
       
        this._signalR.connect()
            .then(
            c => {
                this.connection = c;

            });
    }


    public get Connection() {

        return this.connection;
    }



}