import { userEntity } from '../entity/userEntity';

export class LoginResponse {
    constructor() {
        this.userEntity = new userEntity();
    }
    code: number;
    message: string;
    accessToken: string;
    userEntity = new userEntity();
}