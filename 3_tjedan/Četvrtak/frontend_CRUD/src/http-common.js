import axios, { HttpStatusCode } from "axios";

export default axios.create({
  baseURL: "https://localhost:44362/api",
  headers: {
    "Accept" : "*/*",
    "Content-type": "application/json"
  }
});
