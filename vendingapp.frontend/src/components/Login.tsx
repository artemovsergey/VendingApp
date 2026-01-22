import { useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";

export const Login = () => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();

  const handlerForm = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    console.log(login, password);
    navigate("/")
  };

  return (
    <div className="bg-amber-200 h-screen flex flex-col justify-center items-center ">
      <h1 className="mb-5"> Авторизация</h1>
      <form
        className="p-2 border flex flex-col gap-3 justify-center items-center "
        onSubmit={(e) => handlerForm(e)}
      >
        <input
          type="text"
          placeholder="Login"
          value={login}
          onChange={(e) => setLogin(e.target.value)}
        />
        <input
          type="password"
          placeholder="Password"
          value={password}
          onChange={(e) => setPassword(e.target.value)}
        />
        <button className="bg-amber-500 text-white p-2 w-full" type="submit">
          Войти
        </button>
      </form>

      <pre>
        <span> Login: {login} </span>
        <span> Password: {password} </span>
      </pre>
    </div>
  );
};
