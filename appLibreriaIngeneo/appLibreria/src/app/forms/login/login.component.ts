import { Component, OnInit } from '@angular/core';
import { FormGroup,FormControl,Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { LoginRequest } from 'src/app/module/request/loginRequest';
import { LoginResponse } from 'src/app/module/response/loginResponse';
import { serviceApi } from '../../service/serviceApi'

declare var $: any;

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email : new FormControl('',Validators.required),
    password : new FormControl('',Validators.required)
  })


  constructor(
    private api:serviceApi,
    private route:Router
  ) { }

  ngOnInit(): void {
  }
  
  onLogin(form:LoginRequest){
    this.api.executeMethod("api/Auth/Login", form, (data) => {
      console.log(data);
      let loginResponse:LoginResponse = data;
      if(loginResponse.code==0){
        localStorage.setItem("token",loginResponse.accessToken);
        this.route.navigate(['search']);
      }
    });
  }
}
