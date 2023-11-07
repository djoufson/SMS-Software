import React, { useState } from "react";
import * as yup from "yup";
import { COUNTRIES } from "../utils/countries";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { FormProvider, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { Sidebar } from "flowbite-react";
import SidebarP from "../components/sidebar";
import FooterP from "../components/footer";
import Api from "../libs/api";

const schema = yup
  .object()
  .shape({
    lastName: yup.string().required("Ce champ est requis !"),
    province: yup.string().required("Ce champ est requis !"),
    firstName: yup.string().required("Ce champ est requis !"),
    city: yup.string().required("Ce champ est requis !"),
    street: yup.string().required("Ce champ est requis !"),
    role: yup.string().required("Ce champ est requis !"),
    email: yup
      .string()
      .email("email invalide")
      .required("email invalide")
      .matches(/^\w+([.-]?\w+)*@\w+([.-]?\w+)*(\.\w{2,})+$/, {
        message: "email invalide",
      }),
    phoneIndex: yup.string().trim().required("Sélectionner un indicatif"),
    telefon: yup
      .string()
      .required("Votre numéro de téléphone est invalide")
      .min(9, "Votre numéro de téléphone est invalide"),
    password: yup
      .string()
      .required("Ce champs est requis")
      .min(8, "Le mot de passe doit avoir au moins 8 caractères"),
    cpassword: yup
      .string()
      .required("Il est nécessaire de confirmer votre mot de passe")
      .oneOf(
        [yup.ref("password"), ""],
        "Les mots de passe doivent correspondre"
      ),
  })
  .required();

const Register = () => {
  const ROLES = [
    { type: "admin", label: "Administrateur" },
    { type: "secrétaire", label: "Secrétaire" },
    { type: "étudiant", label: "Etudiant" },
    { type: "Super Admin", label: "Super Administrateur" },
  ];
  const navigate = useNavigate();
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
  } = useForm({
    mode: "onChange",
    resolver: yupResolver(schema),
  });

  const onSubmitHandler = (data: any) => {
    console.log(data);
    Api
      .post("Register/register", {
        firstName: data.firstName,
        lastName: data.lastName,
        email: data.email,
        password: data.password,
        street: data.street,
        city: data,
        zipCode: data.zipCode,
        province: data.province,
        phoneIndex: data.phoneIndex,
        telefon: data.telefon,
      })
      .then((res) => {
        console.log(res.data);
        reset();
        navigate("/users");
      })
      .catch((err) => [console.log(err)]);
  };

  //const[user,setUser] = useState({firstName:"",lastName:"",email:"",password:"",cpassword:"",province:"",phoneIndex:"",telefon:"", street:"", city:"", zipCode:""})

  // const handleSubmit = (e: any) => {
  //   e.preventDefault();
  //   console.log(user);

  //   const errors = schema.validate(user);

  //   if (errors.length) {
  //     console.log(errors);
  //     return;
  //   } else {
  //     axios
  //       .post("http://localhost:5078/api/Register/register", {
  //         firstName: user.firstName,
  //         lastName: user.lastName,
  //         email: user.email,
  //         password: user.password,
  //         street: user.street,
  //         city: user,
  //         zipCode: user.zipCode,
  //         province: user.province,
  //         phoneIndex: user.phoneIndex,
  //         telefon: user.telefon
  //       })
  //       .then((res: any) => {
  //         console.log(res.data);
  //         navigate("/login", { state: res.data.token });
  //       })
  //       .catch((err) => [console.log(err)]);
  //   }
  // };

  return (
    <div className="flex flex-col overflow-auto">
      <section className="container mt-10">
        <div className="rounded shadow-lg my-auto md:mx-auto p-4 flex min-h-full flex-col lg:px-8">
          <div className="sm:mx-auto sm:w-full sm:max-w-sm">
            <h1 className="mx-auto h-10 w-auto texl-3xl font-bold">
              Enregistrez un nouvel utilisateur
            </h1>
            <div>
              <form onSubmit={handleSubmit(onSubmitHandler)}>
                <div className="flex flex-grow md:flex-row justify-between">
                  <div className="mt-4 w-fit">
                    <input
                      type="text"
                      autoComplete="nom"
                      required
                      placeholder="Nom(s)"
                      {...register("lastName")}
                      className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className="text-red-500  text-xs block sm:inline">
                      {errors.lastName?.message}
                    </p>
                  </div>
                  <div className="row-span-2">
                    <div className="mt-4 w-fit">
                      <input
                        type="text"
                        autoComplete="prénom"
                        required
                        {...register("firstName")}
                        placeholder="Prénom(s)"
                        className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                      />
                      <p className="text-red-500  text-xs block sm:inline">
                        {errors.firstName?.message}
                      </p>
                    </div>
                  </div>
                </div>
                <div>
                  <div className="mt-2">
                    <input
                      type="email"
                      autoComplete="current-email"
                      required
                      placeholder="Email"
                      title="Entrez votre adresse mail"
                      {...register("email")}
                      className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className="text-red-500  text-xs block sm:inline">
                      {errors.email?.message}
                    </p>
                  </div>
                </div>
                <div>
                  <div className="mt-2">
                    <input
                      type="password"
                      autoComplete="current-password"
                      required
                      placeholder="Mot de passe"
                      {...register("password")}
                      title="Entrez votre mot de passe"
                      className="pl-2 block text-left w-full rounded-lg border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className="text-red-500  text-xs block sm:inline">
                      {errors.password?.message}
                    </p>
                  </div>
                </div>
                <div>
                  <div className="mt-2">
                    <input
                      type="password"
                      required
                      {...register("cpassword")}
                      placeholder="Confirmer votre mot de passe"
                      title="Confirmer votre mot de passe"
                      className="pl-2 block text-left w-full rounded-lg  border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className=" text-red-500 text-xs block sm:inline">
                      {errors.cpassword?.message}
                    </p>
                  </div>
                </div>
                <div>
                  <div className="mt-2">
                    <select
                      {...register("role")}
                      className="pl-2 rounded-tl-lg rounded-tr-lg border-gray-300 shadow-sm md:rounded-bl-lg md:rounded-tr-none"
                    >
                      <option value="">
                        Quel est le rôle de cet utilisateur?
                      </option>
                      {ROLES.map((role: any, index) => (
                        <option key={index} value={role.type}>
                          {role.label}
                        </option>
                      ))}
                    </select>
                    <p className=" text-red-500 text-xs block sm:inline">
                      {errors.role?.message}
                    </p>
                  </div>
                </div>
                <div className="mt-5 flex flex-col md:flex-row">
                  <select
                    {...register("phoneIndex")}
                    className="pl-2 rounded-tl-lg rounded-tr-lg border-gray-300 shadow-sm md:w-1/3 md:rounded-bl-lg md:rounded-tr-none"
                  >
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
                  <p className="text-red-500  text-xs block sm:inline">
                    {errors.phoneIndex?.message}
                  </p>
                  <input
                    placeholder="Votre téléphone"
                    type="number"
                    autoComplete="false"
                    className="pl-2 block text-left w-full rounded-lg  border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    {...register("telefon")}
                  />
                  <p className="text-red-500  text-xs block sm:inline">
                    {errors.telefon?.message}
                  </p>
                </div>
                <div className="flex gap-2 flex-row justify-between">
                  <div className="mt-4">
                    <input
                      title="région"
                      type="text"
                      required
                      {...register("province")}
                      placeholder="Région"
                      className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className="text-red-500  text-xs block sm:inline">
                      {errors.province?.message}
                    </p>
                  </div>
                  <div className="mt-4">
                    <input
                      type="text"
                      required
                      placeholder=" ville"
                      {...register("city")}
                      className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    />
                    <p className="text-red-500  text-xs block sm:inline">
                      {errors.city?.message}
                    </p>
                  </div>
                  <div className="row-span-2">
                    <div className="mt-4">
                      <input
                        title=" quartier"
                        type="text"
                        required
                        placeholder="quartier"
                        {...register("street")}
                        className="pl-2 block text-left w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                      />
                      <p className="text-red-500  text-xs block sm:inline">
                        {errors.street?.message}
                      </p>
                    </div>
                  </div>
                </div>
                <div>
                  <button
                    type="submit"
                    className="transition ease-in-out delay-150  hover:-translate-y-1 hover:scale-100  duration-300 mt-5 flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                  >
                    Enregistrer
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </section>
    </div>
  );
};

export default Register;
