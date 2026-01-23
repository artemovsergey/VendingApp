import { Module } from "./Module";

export const Home = () => {
  return (
    <div className="home">
      <h1> Личный кабинет</h1>
      <div className="blocks">
        <Module title="Эффективность сети" />
        <Module title="Состояние сети" />
        <Module title="Сводка" />
        <Module title="Динамика продаж" />
        <Module title="Новости" />
      </div>
    </div>
  );
};
