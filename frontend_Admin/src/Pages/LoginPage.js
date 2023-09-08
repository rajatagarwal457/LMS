import {useState} from "react";
import React from 'react';
const LoginPage = () =>{
    const [email,setEmail] = useState('');
    const[pwd,setPwd] = useState('');
    const handleEmail = (event)=>{
        setEmail(event.target.value);
    }
    const handlePwd = (event) =>{
        setPwd(event.target.value);
    }
    const handleSubmit =(event) =>{
        alert(email);
        alert(pwd);
    }
    return(
        <div>
            <table>
                <tbody>
                    <tr>
                        <td>Admin Email: </td>
                        <td><input type="email" value={email} id="email" onChange={handleEmail}/></td>
                    </tr>
                    <tr>
                        <td>Admin Password: </td>
                        <td><input type="password" value={pwd} id="pwd" onChange={handlePwd}/></td>
                    </tr>   
                    <tr>
                        <td><button type="submit" onClick={handleSubmit}>Login as Admin</button></td>
                    </tr>
                        
                </tbody>
            </table>
        </div>
    )
}
export default LoginPage;