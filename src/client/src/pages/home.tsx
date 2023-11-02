import axios from "axios";
import React, { useState } from "react";
import { useLocation } from "react-router";

function Home() {
  const location = useLocation();
  const token = location.state;
  const [users, setUsers] = useState([]);
  const showUsers = () => {
    const config = { headers: { Authorization: `Bearer ${token}` } };
    axios
      .get("https://localhost:5078/api/Users", config)
      .then((response) => {
        setUsers(response.data);
      })
      .catch((error) => {
        console.error(error);
      });
  };

  return <div>home</div>;
}

export default Home;
