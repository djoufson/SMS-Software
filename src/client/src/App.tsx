import { useState } from "react";
import reactLogo from "./assets/react.svg";
import "./App.css";
import Login from "./pages/login";
import SignUp from "./pages/register";
import Router, { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/home";
import Sidebar from "./components/sidebar";
import Layout from "./components/layout";
import Users from "./components/users";
import Profile from "./components/Profile";
import Sanction from "./components/sanction";
import Paiement from "./components/paiement";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        
          <Route path="/home" element={<Layout />}>
            <Route index element={<Profile />} />
            <Route path="users" element={<Users />} />
            <Route path="sanctions" element={<Sanction />} />
            <Route path="paiements" element={<Paiement />} />
            <Route path="register" element={<SignUp />} />
          </Route>
      
        <Route path="/" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
