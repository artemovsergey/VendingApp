export const Header = (props: { children: React.ReactNode }) => {
    return (
        <header className="p-2 flex flex-row justify-between items-center ">
            {props.children}
        </header>
    )
}