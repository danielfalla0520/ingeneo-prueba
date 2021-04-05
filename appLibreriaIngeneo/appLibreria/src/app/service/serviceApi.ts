import { Injectable } from '@angular/core'
import { LoginRequest } from '../module/request/loginRequest'
import { LoginResponse } from '../module/response/loginResponse'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable, observable } from 'rxjs'

@Injectable({
    providedIn: 'root'
})
export class serviceApi {

    url: string = "https://localhost:44393/";

    constructor(
        private http: HttpClient
    ) { }

    public executeMethod(nameMethod, objData, returnData) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/json; charset=utf-8');
        this.http.post(this.url + nameMethod, JSON.stringify(objData), { headers: headers })
            .subscribe(data => {
                returnData(data);
            },
                err => {
                    console.log("Error")
                }
            );
    }
}