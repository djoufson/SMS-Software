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
    <div className="flex flex-row gap-4 w-full">
      {loading && <Loader />}
      {/* {isEmpty? 
        <div className="bg-white p-10 flex-1">
          <img src="./assets/empty.svg" width="400" height="400" />
        </div>: */}
      {!loading && (
        <div className="bg-white px-4 pt-3 rounded-sm border-gray-200 flex-1">
          <strong>Tous les utilisateurs </strong>
          <hr />
          <div className="mt-3">
            <table className="gap-3 table">
              <thead>
                <tr className="table-header-group">
                  <td>Noms</td>
                  <td>Prénoms</td>
                  <td>Email</td>
                  <td>Région</td>
                  <td>Ville</td>
                  <td>Quartier</td>
                  <td>Numéros de téléphone</td>
                  <td>Rôle</td>
                  <td>Sanctions</td>
                  <td>Actions</td>
                </tr>
              </thead>
              <tbody>
                {users.length > 0 &&
                  users.map((user: any, index) => (
                    <tr key={index}>
                      <td>{user.firstName}a</td>
                      <td>{user.lastName}a</td>
                      <td>{user.email}a</td>
                      <td>{user.province}a</td>
                      <td>{user.city}a</td>
                      <td>{user.street}a</td>
                      <td>{"+" + user.phoneIndex + user.telefon}a</td>
                      <td>{user.roles}a</td>
                      <td>{}va</td>
                      <td>
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
  );
}
export default Users;
