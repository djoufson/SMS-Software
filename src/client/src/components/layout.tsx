import React from "react";
import SidebarP from "./sidebar";
import { Outlet } from "react-router-dom";
import FooterP from "./footer";

function Layout() {
  return (
    <div className="flex items-center justify-center top-0 lg:max-w-7xl border-gray-200 rounded">
      <div className="grid grid-cols-7 space-x-1 w-screen divide-x-2">
        <div className="z-10 col-span-1">
          <SidebarP />
        </div>
        <div className="z-0 col-span-6 sm:col">{<Outlet />}</div>
      </div>
    </div>
  );
}

export default Layout;
