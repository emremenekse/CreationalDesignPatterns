


class MailService {
    private constructor() {
        console.log("MailService Object Created");
    }

    static mailServices: { [key: string]: MailService } = {}

    static getInstance(key: string) {
        if (this.mailServices[key] == null) {
            this.mailServices[key] = new MailService();
        }

        const mailService = this.mailServices[key];
        return mailService;
    }

    private _mail?: string;
    get mail(): string {
        if (this._mail == null) {
            return "";
        }
        return this._mail;
    }
    set mail(value: string) {
        
        this._mail = value;
    }
    private _userName?: string;
    get username(): string {
        if (this._userName == null) {
            return "";
        }
        return this._userName;
    }
    set username(value: string) {

        this._userName = value;
    }
    private _password?: string;
    get password(): string {
        if (this._password == null) {
            return "";
        }
        return this._password;
    }
    set password(value: string) {

        this._password = value;
    }
}

const gmail: MailService = MailService.getInstance("gmail");
const hotmail: MailService = MailService.getInstance("hotmail");

gmail.mail = "...";
gmail.password = "...";
gmail.username = "...";

const gmail2: MailService = MailService.getInstance("gmail");
const hotmail2: MailService = MailService.getInstance("hotmail");

hotmail.mail = "...";
hotmail.password = "...";
hotmail.username = "...";