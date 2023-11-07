import { useState } from "react";
import reactLogo from "./assets/react.svg";
import "./App.css";
import Login from "./pages/login";
import SignUp from "./pages/signup";
import Router, { BrowserRouter, Route, Routes } from "react-router-dom";
import Home from "./pages/home";
import Sidebar from "./components/sidebar";
import Layout from "./components/layout";
import Users from "./components/users";
import Profile from "./components/Profile";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/home" element={<Layout />}>
          <Route index element={<Profile />} />
          <Route path="users" element={<Users />} />
          <Route path="register" element={<SignUp />} />
        </Route>
        <Route path="/" element={<Login />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
