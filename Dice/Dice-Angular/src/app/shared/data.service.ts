import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";


@Injectable()
export class DataService {

    private _value: any;

    public value() {
        return this._value
    }
    public setValue(v) {

        this._value = v;
    }

}