import React from "react";

function Loader() {
  return (
    <div className="z-0 px-4 absolute pt-3 flex-1 rounded-sm shadow-md w-screen sm:w-full animate-pulse duration-300 h-screen">
      <div className="h-48 w-full rounded-sm mb-5 bg-gray-100">
        <p className="text-center text-sm">Veuillez patienter...</p>
      </div>
      <div className="flex-1 px-4 py-8 space-y-4 sm:p-8 bg-gray-150">
        <div className="w-full h-6 rounded bg-gray-200"></div>
        <div className="w-full h-6 rounded bg-gray-300"></div>
        <div className="w-3/4 h-6 rounded bg-gray-100"></div>
      </div>
    </div>
  );
}

export default Loader;
