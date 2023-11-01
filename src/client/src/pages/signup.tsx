import React, { useState } from "react";
import * as yup from "yup";
import { COUNTRIES } from "../utils/countries";
import { Roles } from "../entities/role";
import { useNavigate } from "react-router-dom";

// const schema = yup
//   .object({
//     lastName: yup.string().required("Ce champ est requis !"),
//     province: yup.string().required("Ce champ est requis !"),
//     firstName: yup.string().required("Ce champ est requis !"),
//     city: yup.string().required("Ce champ est requis !"),
//     street: yup.string().required("Ce champ est requis !"),
//     email: yup
//       .string()
//       .email(EMAIL_ERROR_MESSAGE)
//       .required(EMAIL_ERROR_MESSAGE)
//       .matches(EMAIL_PATTERN, { message: EMAIL_ERROR_MESSAGE }),
//     phoneIndex: yup.string().trim().required("Sélectionner un indicatif"),
//     telefon: yup
//       .string()
//       .required(PHONE_ERROR_MESSAGE)
//       .min(9, PHONE_ERROR_MESSAGE),
//     password: yup.string().required("Ce champs est requis"),
//     cpassword: yup
//       .string()
//       .required("Il est nécessaire de confirmer votre mot de passe")
//       .oneOf([yup.ref("password"), ""], "Les mots de passe doivent correspondre"),
//   })
//   .required();

// type User = {
//   id?: string;
//   firstName: string;
//   lastName: string;
//   email: string;
//   street: string;
//   city: string;
//   zipCode?: string;
//   province: string;
//   telefon: string;
//   inactive?: true;
//   roles?: Roles;
//   personalId?: string;
//   image?: string;
// };

function SignUp() {
  // const[errorMessage, setErrorMessage]=useState("Une erreur est survenue, nous allons la résoudre sous peu !");
  const navigate = useNavigate();
  const openSignIn = (e: any) => {
    e.preventDefault();
    navigate("/login");
  };

  return (
    <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <img
          className="mx-auto h-10 w-auto"
          src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600"
          alt="School Management System"
        />
        <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
          Inscrivez-vous
        </h2>
        <div className="">
          <form className="" action="#" method="POST">
            <div className="flex flex-col md:flex-row justify-between">
              <div className="mt-4 w-fit">
                <input
                  id="nom"
                  title="nom"
                  name="nom"
                  type="nom"
                  autoComplete="nom"
                  required
                  placeholder="Nom(s)"
                  className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
              <div className="row-span-2">
                <div className="mt-4 w-fit">
                  <input
                    id="prenom"
                    title=" prénom"
                    name="prenom"
                    type="prenom"
                    autoComplete="prenom"
                    required
                    placeholder="Prénom(s)"
                    className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                  />
                </div>
              </div>
            </div>

            <div>
              <div className="mt-2">
                <input
                  id="email"
                  name="email"
                  type="email"
                  autoComplete="current-email"
                  required
                  placeholder="Email"
                  title="Entrez votre adresse mail"
                  className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>
            <div>
              <div className="mt-2">
                <input
                  id="password"
                  name="password"
                  type="password"
                  autoComplete="current-password"
                  required
                  placeholder="Mot de passe"
                  title="Entrez votre mot de passe"
                  className="block text-center w-full rounded-lg border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>
            <div>
              <div className="mt-2">
                <input
                  id="cpassword"
                  name="cpassword"
                  type="password"
                  required
                  placeholder="Confirmer votre mot de passe"
                  title="Confirmer votre mot de passe"
                  className="block text-center w-full rounded-lg  border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
            </div>
            <div className="mt-5 flex flex-col md:flex-row">
              <select className="rounded-tl-lg rounded-tr-lg border-gray-300 shadow-sm md:w-1/3 md:rounded-bl-lg md:rounded-tr-none">
                <option data-countrycode="FR" value="">
                  Votre pays
                </option>

                {COUNTRIES.sort((countryA: any, countryB: any) =>
                  countryA.label.localeCompare(countryB.label)
                ).map((country: any) => (
                  <option
                    key={country.code}
                    data-countrycode={country.code}
                    value={country.value}
                  >
                    {country.label}
                  </option>
                ))}
              </select>
              <input
                placeholder="Votre téléphone"
                type="number"
                autoComplete="false"
                className="block text-center w-full rounded-lg  border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                id="phone"
                name="phone"
              />
            </div>
            <div className="flex gap-2 flex-row justify-between">
              <div className="mt-4">
                <input
                  id="province"
                  title="région"
                  name="province"
                  type="province"
                  autoComplete="province"
                  required
                  placeholder="Région"
                  className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
              <div className="mt-4">
                <input
                  id="city"
                  title=" ville"
                  name="city"
                  type="city"
                  autoComplete="city"
                  required
                  placeholder=" ville"
                  className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                />
              </div>
              <div className="row-span-2">
                <div className="mt-4">
                  <input
                    id="street"
                    title=" quartier"
                    name="street"
                    type="street"
                    autoComplete="street"
                    required
                    placeholder=" quartier"
                    className="block text-center w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                  />
                </div>
              </div>
            </div>

            <div>
              <button
                type="submit"
                className="mt-5 flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
              >
                S'inscrire
              </button>
            </div>
          </form>

          <p className="mt-10 text-center text-sm text-gray-500">
            Vous avez déjà un compte?
            <a
              onClick={openSignIn}
              className="ml-2 font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
            >
              Connectez-vous
            </a>
          </p>
        </div>
      </div>
    </div>
  );
}

export default SignUp;
