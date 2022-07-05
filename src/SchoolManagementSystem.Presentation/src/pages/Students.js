import React from "react";
import NavBar from "../components/NavBar/NavBar";
import CRUD_Table from "../components/Table/CRUD_Table";
import Login from "../components/Login/Login";
import {useState} from 'react';
import axios from "axios";

const Students = () => {

    
    function levels(){
        var list = [];
        //var arr = [list];
        axios.get("https://localhost:5001/api/EducationEnum")
            .then(resp=>{
                resp.data.forEach(element => {
                   list.push({
                    text: element,
                    value: element,
                   })
                });
            });
        console.log(list);
        return list;
    }

    function filtersFoundSubMenu(comparer, count){
        var children = [];
        for (let index = 0; index < count; index++) {
            let val = 50 * index;
            children.push({
                text: val,
                value: [comparer, val]
            });  
        }        
        return children;
    }

    const [loggedIn] = useState(()=>{
        if (localStorage['token'] == null)
            return false;

        let respOk = true;

        const JWT = JSON.parse(localStorage['token']);

        axios.get("https://localhost:5001/api/Authenticate/loggedIn", 
                    { headers: { "Authorization": `Bearer ${JWT.token}` } })
                .catch((err) => {
                respOk = false;
                console.log(err.response);
            });

        return respOk;
    });
         
    if (!loggedIn)
        window.location.replace("http://localhost:3000/");

    const columns = [
        {
            title: 'Nombre',
            dataIndex: 'name',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.name.localeCompare(b.name)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el nombre.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el nombre."
                },
                {
                    pattern: /^\S{2,}(\s\S{2,})?(\s\S{2,})?(\s\S{2,})?$/,
                    message: 'El nombre solo puede contener letras (dos como mínimo). En caso de ser compuesto, deben estar separados por un único espacio.'
                },
            ]
        },
        {
            title: 'Apellidos',
            dataIndex: 'lastName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.lastName.localeCompare(b.lastName)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los apellidos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los apellidos."
                },
                {
                    pattern: /^\S{2,}(\s\S{2,})?(\s\S{2,})?(\s\S{2,})?$/,
                    message: 'Los apellidos solo pueden contener letras (dos como mínimo) y estar separados por un único espacio.'
                },
            ]
        },
        {
            title: 'Carnet de identidad',
            dataIndex: 'idCardNo',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.idCardNo.localeCompare(b.idCardNo)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el carnet de identidad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el carnet de identidad."
                },
                {
                    pattern: /^\d{11}$/,
                    message: 'El carnet de identidad solo puede contener números y tiene tamaño 11.'
                }
            ]
        },
        {
            title: 'Dirección',
            dataIndex: 'address',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.address.localeCompare(b.address)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la dirección.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la dirección."
                }
            ]
        },
        {
            title: 'Grado de escolaridad',
            dataIndex: 'scholarityLevel',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.scholarityLevel.localeCompare(b.scholarityLevel)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca el grado de escolaridad.",
                },
                {
                    whitespace: true,
                    message: "Introduzca el grado de escolaridad."
                }
            ],
            filters: levels(),            
            onFilter: (value, record) => record.scholarityLevel
                                    .toUpperCase().indexOf(value.toUpperCase()) === 0,
        },
        {
            title: 'Fecha de inicio en la sede',
            dataIndex: 'dateBecomedMember',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.dateBecomedMember.localeCompare(b.dateBecomedMember)
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca la fecha de inicio en la sede.",
                },
                {
                    whitespace: true,
                    message: "Introduzca la fecha de inicio en la sede."
                }
            ]
        },
        {
            title: 'Teléfono',
            dataIndex: 'phoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.phoneNumber - b.phoneNumber
            },
            rules: [
                {
                    whitespace: true,
                    message: "Introduzca el número de teléfono."
                }
            ]
        },
        {
            title: 'Fondos',
            dataIndex: 'founds',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.founds - b.founds
            },
            rules: [
                {
                    required: true,
                    message: "Introduzca los fondos.",
                },
                {
                    whitespace: true,
                    message: "Introduzca los fondos."
                }
            ],
            filters: [
                {
                    text: "Mayor",
                    value: "",
                    children: filtersFoundSubMenu(">=", 11)
                },
                {
                    text: "Menor",
                    value: "",
                    children: filtersFoundSubMenu("<=", 11)
                }
            ],
            onFilter: (value, record) => {
                console.log(value);
                if (value[0] == ">="){
                    return record.founds >= value[1];
                } else {
                    return record.founds <= value[1];
                }
            }
        },
        {
            title: 'Nombre del tutor',
            dataIndex: 'tuitorName',
            editable: true,
            dataType: 'text',
            sorter: {
                compare: (a, b) => a.tuitorName.localeCompare(b.tuitorName)
            },
            rules: [
            ],
        },
        {
            title: 'Teléfono del tutor',
            dataIndex: 'tuitorPhoneNumber',
            editable: true,
            dataType: 'number',
            sorter: {
                compare: (a, b) => a.tuitorPhoneNumber - b.tuitorPhoneNumber
            },
            rules: [
            ]
        }        
    ];

    const tableID = 'StudentsTable';
    const searchboxID = 'StudentsSearchbox';

    return (
        <div>
            <NavBar></NavBar>
            <CRUD_Table 
                title={"Estudiantes"} 
                columns={columns} 
                operations={["edit","delete","add","details","trash"]}
                url={"https://localhost:5001/api/Students"}
                tableID={tableID}
                searchboxID={searchboxID}
                link={"../StudentDetails"}
                recycle_link={"../StudentsRecycleBin"}
            thereIsDropdown={false}
                        FormsInitialValues={{ key: "string" }}
            >
            </CRUD_Table>
        </div>
    );
}

export default Students;