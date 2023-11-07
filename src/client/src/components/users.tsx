import axios from "axios";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Loader from "./loader";
import RecentUser from "./RecentUser";

function Users() {
  const location = useLocation();
  const token = location.state;
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isEmpty, setIsEmpty] = useState(true);

  useEffect(() => {
    const config = { headers: { Authorization: `Bearer ${token}` } };
    const fetchUser = async () => {
      setLoading(true);
      try {
        const { data: response } = await axios.get(
          "https://localhost:5078/api/Users",
          config
        );
        setUsers(response);
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
                  <tr className="table-header-group bg-gray-50 text-left dark:bg-meta-4">
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white xl:pl-11">
                      Noms
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Prénoms
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Email
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Région
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Ville
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Quartier
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Numéros de téléphone
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Rôle
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Sanctions
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black dark:text-white">
                      Actions
                    </th>
                  </tr>
                </thead>
                <tbody>
                  {users.length > 0 &&
                    users.map((user: any, index) => (
                      <tr key={index}>
                        <td className="border-b text-black border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.firstName + "a"}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.lastName}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.email}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.province}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.city}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.street}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {"+" + user.phoneIndex + user.telefon}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {user.roles}a
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          {}va
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p dark:border-strokedark xl:pl-11">
                          <button className="bg-indigo-600 rounded text-white justify-center hover:bg-indigo-500">
                            Modifier
                          </button>
                          <button className="bg-red-600 rounded text-white justify-center hover:bg-red-500">
                            Supprimer
                          </button>
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
