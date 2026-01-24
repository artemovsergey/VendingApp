import { useState } from "react"
import { toast } from "react-toastify"

export const Module = (props: { children: React.ReactNode, title: string }) => {

    const [isHide, setIsHide] = useState(false)

    return (
        <>

            {!isHide && <div className="flex flex-col gap-3 p-5 border">

                <h1 className="bg-gray-400 p-3"> {props.title} </h1>

                <div>
                    {props.children}
                </div>

                <div className="p-2 flex flex-row gap-2 justify-between items-center mt-auto self-end">

                    <button className="flex border px-2 h-min hover:bg-gray-300"
                        onClick={() => { setIsHide(!isHide); toast("Скрыта панель") }}>X</button>
                </div>


            </div>}
        </>
    )
}