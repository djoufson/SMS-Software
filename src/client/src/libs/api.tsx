import axios from "axios";
import env from "../env.json";

const apiUrl = (url: any) => {
  return `${env.apiUrl}/${url}`;
};

const get = (url: any) => {
  return axios.get(apiUrl(url), {});
};

const post = (url: any, data: any) => {
  return axios.post(apiUrl(url), data);
};

const put = (url: any, data: any) => {
  return axios.put(apiUrl(url), data);
};

export default {
  get,
  post,
  put,
};
