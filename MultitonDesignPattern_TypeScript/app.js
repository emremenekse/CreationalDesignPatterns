"use strict";
class MailService {
    constructor() {
        console.log("MailService Object Created");
    }
    static getInstance(key) {
        if (this.mailServices[key] == null) {
            this.mailServices[key] = new MailService();
        }
        const mailService = this.mailServices[key];
        return mailService;
    }
    get mail() {
        if (this._mail == null) {
            return "";
        }
        return this._mail;
    }
    set mail(value) {
        this._mail = value;
    }
    get username() {
        if (this._userName == null) {
            return "";
        }
        return this._userName;
    }
    set username(value) {
        this._userName = value;
    }
    get password() {
        if (this._password == null) {
            return "";
        }
        return this._password;
    }
    set password(value) {
        this._password = value;
    }
}
MailService.mailServices = {};
const gmail = MailService.getInstance("gmail");
const hotmail = MailService.getInstance("hotmail");
gmail.mail = "...";
gmail.password = "...";
gmail.username = "...";
const gmail2 = MailService.getInstance("gmail");
const hotmail2 = MailService.getInstance("hotmail");
hotmail.mail = "...";
hotmail.password = "...";
hotmail.username = "...";
//# sourceMappingURL=app.js.map