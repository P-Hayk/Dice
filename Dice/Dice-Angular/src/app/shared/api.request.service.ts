import { Injectable } from "@angular/core";
import { Request, RequestMethod, RequestOptions, Headers, Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/Rx';
import * as _ from "lodash";

import { Router } from '@angular/router';

@Injectable()

export class ApiRequestService {

    constructor(private http: Http,private route: Router) {


    }
    private request(method: RequestMethod, path: string, body?: any): Observable<any> {

        // set request url
        const url: string = `http://localhost:52945/${path}`;

        // set request headers
        const headers: Headers = new Headers({
            'Accept': 'application/json',
            'Content-Type': 'application/json',
        });

        const options: RequestOptions = new RequestOptions({
            url: url,
            method: method,
            headers: headers,
            withCredentials: true 
        });

        if (!_.isUndefined(body)) {
            options.body = JSON.stringify(body);
        }
        
        //headers.set('Authorization',JSON.stringify(body.RequestObject));

        const request = new Request(options);

        return this.http.request(request).
        map(res => res.json()).
        catch(error=>{
            return Observable.throw(error);
        });
    }

    private postRequest(path: string, body: object) {
        return this.request(RequestMethod.Post, path, body);
    }


    public Request(body: any) {
        return this.postRequest('api/Main', body);
    }
}