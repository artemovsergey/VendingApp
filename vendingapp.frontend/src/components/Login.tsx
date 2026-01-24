import { useEffect, useState, type FormEvent } from "react";
import { useNavigate } from "react-router-dom";
import { toast } from "react-toastify";

export const Login = () => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const navigate = useNavigate();
  const [imageLoad, SetImageLoad] = useState("/");

  const handlerForm = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const data = await fetch("http://localhost:5208/api/Auth", {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        login: `${login}`,
        password: `${password}`
      })
    })
    if (data.status != 200) {
      console.log(data.status)
      toast("Ошибка авторизации")
      return;
    } else {
      const user = await data.json();
      localStorage.setItem("user", JSON.stringify(user))
      console.log(user.fullName.split(" ")[0], `${user.fullName.split(" ")[1][0]}.`, `${user.fullName.split(" ")[1][0]}.`, user.role);
      SetImageLoad(user.image);
      navigate("/")
    }


  };

  useEffect(() => {
    console.log("login")
  }, [])


  return (
    <div className="h-screen flex flex-col justify-center items-center ">
      <h1 className="mb-5 text-gray-500 text-3xl"> Авторизация</h1>
      <form
        className="p-3   border flex flex-col gap-3 justify-center items-center "
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
        <button className="bg-gray-500 text-white p-2 w-full" type="submit">
          Войти
        </button>
      </form>

      <pre className="p-2">
        <span> Login: {login} </span>
        <span> Password: {password} </span>
      </pre>
    </div>
  );
};
