import { useEffect, useState } from "react";
import { Module } from "./Module";

export const Home = () => {

  const [vendingMachines, setVendingMachines] = useState<any>([])
  const [successMachines, setSuccessMachines] = useState<any>([])

  useEffect(() => {

    const getMachines = async () => {
      const data = await fetch("http://localhost:5208/api/vendingMachines")
      const vendingMachines = await data.json()
      console.log(vendingMachines)
      setVendingMachines(vendingMachines)
      setSuccessMachines(vendingMachines.filter((m: { status: string; }) => m.status == "Работает"))
    }

    getMachines();

  }, [])

  return (
    <>
      <div className="flex-1 flex flex-col gap-3 p-5">
        <h1> Личный кабинет</h1>
        <div className="flex flex-row max-w-min gap-5">

          <Module title="Эффективность сети">
            <div className="flex flex-col gap-1 p-2 w-max">
              <span> Все автоматы: {vendingMachines.length} </span>
              <span> Работающие автоматы: {successMachines.length} </span>
              <span> Процент: {Math.round((successMachines.length / vendingMachines.length) * 100)} % </span>
            </div>
          </Module>

          <Module title="Сводка">
            <ul>
              <li> данные ...</li>
            </ul>
          </Module>

          <Module title="Новости">
            <ul>
              <li> новости ...</li>
              <li> из api ...</li>
            </ul>
          </Module>

          {/* <Module title="Состояние сети" />
        <Module title="Динамика продаж" />
        <Module title="Новости" /> */}
        </div>
      </div>
    </>
  );
};
