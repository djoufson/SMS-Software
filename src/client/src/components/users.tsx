import axios from "axios";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Loader from "./loader";
import RecentUser from "./RecentUser";
import Api from "../libs/api";
import imgProj from "../assets/img/imgProj";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

function Users() {
  const location = useLocation();
  const token = localStorage.getItem("token");
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isEmpty, setIsEmpty] = useState(true);
  const config = {
    headers: { Authorization: `Bearer ${token}` },
  };

  const ROLES = [
    { type: 0, label: "Administrateur" },
    { type: 1, label: "Secrétaire" },
    { type: 2, label: "Parent" },
    { type: 3, label: "Etudiant" },
  ];

  useEffect(() => {
    const fetchUser = async () => {
      setLoading(true);
      try {
        const { data: response } = await Api.get("Users", config);
        setUsers(response);
        console.log(response);
      } catch (error: any) {
        console.error(error);
      }
      setLoading(false);
    };
    if (users.length > 0) {
      setIsEmpty(false);
    }
    fetchUser();
  }, []);

  return (
    <>
      <div className="flex-1 z-0">{loading && <Loader />}</div>
      <div className="flex flex-row gap-4 w-full">
        {/* {isEmpty? 
        <div className="bg-white p-10 flex-1">
          <img src="./assets/empty.svg" width="400" height="400" />
        </div>: */}
        {!loading && (
          <div className="bg-white px-4 pt-3 rounded-sm border-gray-200 flex-1">
            <strong>Tous les utilisateurs </strong>
            <hr />
            <div className="mt-3">
              <table className="gap-3 table-auto w-full border-gray-600">
                <thead>
                  <tr className="bg-gray-50 text-left dark:bg-meta-4">
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white xl:pl-11">
                      Noms
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Prénoms
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Email
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Région
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Ville
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Quartier
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Numéros de téléphone
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Numéro de pièce d'identité
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Sanctions
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Actions
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {users.length > 0 &&
                    users.map((user: any, index) => (
                      <tr key={index}>
                        <td className="border-b text-black border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.firstName}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.lastName}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.email}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.province}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.city}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.street}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {"+" + user.zipCode + " " + user.telephone}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {user.personalId}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          <div className="flex-row justify-center">
                            <div
                              title="Modifier cet étudiant"
                              className="flex bg-indigo-600 text-sm p-3 rounded-full text-white justify-center hover:bg-indigo-500"
                            >
                              <FontAwesomeIcon
                                icon="pen-to-square"
                                size="lg"
                                style={{ color: "#ffffff" }}
                              />
                            </div>
                            <div
                              title="Supprimer cet étudiant"
                              className="flex mt-2 bg-red-600 p-3 text-sm rounded-full text-white justify-center hover:bg-red-500"
                            >
                              <FontAwesomeIcon
                                icon="trash-can"
                                style={{ color: "#ffffff" }}
                              />
                            </div>
                          </div>
                        </td>
                      </tr>
                    ))}
                </tbody>
              </table>
            </div>
          </div>
        )}
      </div>
    </>
  );
}
export default Users;
