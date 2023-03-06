import { baseurl } from "../app/data";
import axios from "axios";

const controller = "api/Product/";

export const getAll = () => axios.get(baseurl + controller);

export const getOne = (id) => axios.get(baseurl + controller + id.toString());

export const register = (customer) => {
    axios.post(baseurl + controller + "register", 
    {
        "userName": customer.userName,
        "firstName": customer.firstName,
        "lastName": customer.lastName,
        "email": customer.email,
        "address": customer.address,
        "city": customer.city,
        "zipCode": customer.zipCode
      }
    )};

export const login = (username, password) => axios.post(baseurl + controller + `login?username=${username}&password=${password}`);
