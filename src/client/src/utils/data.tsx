export const BACKEND_BASE_PATH = "/api/backend";
export const TOKEN_PAYLOAD = 'TOKEN_PAYLOAD';
export const USER_INFOS = 'USER_INFOS';
export const MESSAGE_VARIABLE_PATTERN = /{{[a-zA-Z0-9_ ]+}}/g;
export const PHONE_PATTERN = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,5}$/;
//export const EMAIL_PATTERN = /^([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})$/;
export const EMAIL_PATTERN = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$/;
/*
export const URL_PATTERN =
  /((https?):\/\/)(www.)?[a-z0-9]+(\.[a-z]{2,}){1,3}(#?\/?[a-zA-Z0-9#]+)*\/?(\?[a-zA-Z0-9-_]+=[a-zA-Z0-9-%]+&?)?$/;
*/
export const URL_PATTERN = /^(https?|ftp):\/\/(([a-z\d]([a-z\d-]*[a-z\d])?\.)+[a-z]{2,}|localhost)(\/[-a-z\d%_.~+]*)*(\?[;&a-z\d%_.~+=-]*)?(\#[-a-z\d_]*)?$/i;

export const STRING_WITH_NUMBERS_REGEXP = /^\D*(\d\D*){10,}$/;
export const PHONE_ERROR_MESSAGE = "Votre numéro de téléphone est invalide";
export const INVALID_ERROR_MESSAGE = 'Ce champ est invalide';
export const EMAIL_ERROR_MESSAGE = 'Votre mail est invalide';
export const REQUIRED_FIELD_ERROR_MESSAGE = 'Ce champ est requis';
export const GLOBAL_ERROR = 'Une erreur est survenue, nous allons la résoudre sous peu';
export const INITIAL_STATE = { stepIndex: 0, campain: {} };
export const UPDATE_CAMPAIN = 'UPDATE_CAMPAIN';
export const UPDATE_STEP_INDEX = 'UPDATE_STEP_INDEX';
export const SET_STATE = 'SET_STATE';
export const RESET_CAMPAIN = 'RESET_CAMPAIN';
export const SET_NB_STEPS = 'SET_NB_STEPS';
export const UPDATE_DATA = 'UPDATE_DATA';
