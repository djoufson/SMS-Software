const BACKEND_BASE_PATH = "/api/backend";
const TOKEN_PAYLOAD = 'TOKEN_PAYLOAD';
const USER_INFOS = 'USER_INFOS';
const MESSAGE_VARIABLE_PATTERN = /{{[a-zA-Z0-9_ ]+}}/g;
const PHONE_PATTERN = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,5}$/;
//const EMAIL_PATTERN = /^([\w-\.]+)@((?:[\w]+\.)+)([a-zA-Z]{2,4})$/;
const EMAIL_PATTERN = /^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$/;
/*
const URL_PATTERN =
  /((https?):\/\/)(www.)?[a-z0-9]+(\.[a-z]{2,}){1,3}(#?\/?[a-zA-Z0-9#]+)*\/?(\?[a-zA-Z0-9-_]+=[a-zA-Z0-9-%]+&?)?$/;
*/
const URL_PATTERN = /^(https?|ftp):\/\/(([a-z\d]([a-z\d-]*[a-z\d])?\.)+[a-z]{2,}|localhost)(\/[-a-z\d%_.~+]*)*(\?[;&a-z\d%_.~+=-]*)?(\#[-a-z\d_]*)?$/i;

const STRING_WITH_NUMBERS_REGEXP = /^\D*(\d\D*){10,}$/;
const PHONE_ERROR_MESSAGE = "Votre numéro de téléphone est invalide";
const INVALID_ERROR_MESSAGE = 'Ce champ est invalide';
const EMAIL_ERROR_MESSAGE = 'Votre mail est invalide';
const REQUIRED_FIELD_ERROR_MESSAGE = 'Ce champ est requis';
const GLOBAL_ERROR = 'Une erreur est survenue, nous allons la résoudre sous peu';
const INITIAL_STATE = { stepIndex: 0, campain: {} };
const UPDATE_CAMPAIN = 'UPDATE_CAMPAIN';
const UPDATE_STEP_INDEX = 'UPDATE_STEP_INDEX';
const SET_STATE = 'SET_STATE';
const RESET_CAMPAIN = 'RESET_CAMPAIN';
const SET_NB_STEPS = 'SET_NB_STEPS';
const UPDATE_DATA = 'UPDATE_DATA';