import axios from "axios";
import React, { useState } from "react";
import { useLocation } from "react-router";
import Sidebar from "../components/sidebar";
import Users from "../components/users";

function Home() {
  // const location = useLocation();
  // const token = location.state;
  // const [users, setUsers] = useState([]);
  // const showUsers = () => {
  //   const config = { headers: { Authorization: `Bearer ${token}` } };
  //   axios
  //     .get("https://localhost:5078/api/Users", config)
  //     .then((response) => {
  //       setUsers(response.data);
  //     })
  //     .catch((error) => {
  //       console.error(error);
  //     });
  // };

  return (
    <>
      <div className="bg-cover min-h-screen h-screen justify-normal">
        <Sidebar />
        <section>
          <Users />
        </section>
      </div>
    </>
  );
}

export default Home;
