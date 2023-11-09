import axios from "axios";
import React, { useEffect, useState } from "react";
import { useLocation } from "react-router-dom";
import Loader from "./loader";
import RecentUser from "./RecentUser";
import Api from "../libs/api";

function Sanction() {
  const token = localStorage.getItem("token");
  const [sanctions, setSanctions] = useState([]);
  const [loading, setLoading] = useState(true);
  const [isEmpty, setIsEmpty] = useState(true);
  const config = {
    headers: { Authorization: `Bearer ${token}` },
  };

  useEffect(() => {
    const fetchSanctions = async () => {
      setLoading(true);
      try {
        const { data: response } = await Api.get("Sanction", config);
        setSanctions(response);
        console.log(response);
      } catch (error: any) {
        console.error(error);
      }
      setLoading(false);
    };
    if (sanctions.length > 0) {
      setIsEmpty(false);
    }
    fetchSanctions();
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
            <strong>Toutes les sanctions </strong>
            <hr />
            <div className="mt-3">
              <table className="gap-3 table-auto w-full border-gray-600">
                <thead>
                  <tr className="bg-gray-50 text-left dark:bg-meta-4">
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white xl:pl-11">
                      Etudiants
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Motif
                    </th>
                    <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Montant
                    </th>
                    {/* <th className="min-w-[120] py-4 px-4 font-medium text-black text-sm dark:text-white">
                      Actions
                    </th> */}
                  </tr>
                </thead>
                <tbody>
                  {sanctions.length > 0 &&
                    sanctions.map((sanction: any, index) => (
                      <tr key={index}>
                        <td className="border-b text-black border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {sanction.studentEmail}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {sanction.motif}
                        </td>
                        <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          {sanction.amount}
                        </td>
                        {/* <td className="border-b border-[#eee] py-5 px-4 pl-p text-sm dark:border-strokedark xl:pl-11">
                          <div className="flex-col justify-center">
                            <button className="flex bg-indigo-600 text-sm p-3 rounded text-white justify-center hover:bg-indigo-500">
                              Modifier
                            </button>
                            <button className="flex mt-2 bg-red-600 p-3 text-sm rounded text-white justify-center hover:bg-red-500">
                              Supprimer
                            </button>
                          </div>
                        </td> */}
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
export default Sanction;
