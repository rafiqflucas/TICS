import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Config } from 'protractor';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent
{
  constructor(private http: HttpClient) { }


  login_message = "Hello, Please Login";
  submit_button_disabled = true;
  configUrl = 'assets/config.json';

  checkInputs()
  {

  }

  login() {
    let url  = "http://www.test.com"; //just a place holder
    //get username and password
    //call service to validate
    this.http.get(url);
    //if true, load user data and move to the home page

    //session info???

       
  }

  getConfig() {
    return this.http.get<Config>(this.configUrl);
  }

}
