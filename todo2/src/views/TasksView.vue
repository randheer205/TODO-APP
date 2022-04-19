<template>
    <div style="padding:15px;border-left:2px solid black;border-right:2px solid black;min-width:50%;margin:15px;margin-left:10px;">
        <button type="button" class="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#exampleModal1" @click="addClick1()"><img src="../assets/add_white_24dp.svg"/></button>

        <div v-for="task in tasks" :key="task.TaskId">
                <div class="btn btn-outline-success" style="min-width:100%;margin:10px;" @click="showTask(task)">
                    
                    <div style="display:flex;">
                    
                        <span v-if="task.Favourite==true" style="max-width:15%;"><img src="../assets/star_black_24dp.svg"/></span>
                        <span v-else style="min-width:24px;"></span>
                        <div style="text-align:left;">
                            <h4>{{task.Name}}</h4>
                            {{task.CategoryName}}
                            <br>
                            <span v-if="task.Priority=='Low'" style="color:blue">Neglected Child {{task.Priority}}</span>
                            <span v-if="task.Priority=='Medium'" style="color:yellow">Its Meh {{task.Priority}}</span>
                            <span v-if="task.Priority=='High'" style="color:orange">Its {{task.Priority}}</span>
                            <span v-if="task.Priority=='TOP'" style="color:red">HIGH ALERT {{task.Priority}}</span>
                            {{task.DueDate}}
                        </div>

                    </div>
                    
                </div>
        </div> 

        <div class="modal fade" id="exampleModal1" tabIndex="-1"
            aria-labelledby="exampleModalLabel" arai-hidden="true">
            
            <div class="modal-dialog modal-lg modal-dialog-centerd">
                
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">{{modalTitle}}</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal"
                        aria-label="Close"></button>
                    </div>

                    <div class="modal-body">
                        
                        <div class="input-group mb-3">
                            <span class="input-group-text">Task</span>
                            <input type="text" class="form-control" v-model="Name">
                        </div>
                        <div style="margin:5px;">
                            <h5 style="margin:5px;">Favourite</h5>
                            <input type="radio" id="one" value=true v-model="Favourite">
                            <label style="margin:5px;" for="one">True</label>
                            <br>
                            <input type="radio" id="two" value=false v-model="Favourite">
                            <label style="margin:5px;" for="two">False</label>
                            
                            <div style="margin:5px;">
                                Category : 
                                <select v-model="CategoryName">
                                    <option v-for="cat in categories" :key="cat.TaskId">{{cat.CategoryName}}</option>
                                </select>
                            </div>
                            <div style="margin:5px;">
                            Priority : 
                            <input style="visibility:hidden;" type="radio" id="Pone" value="Low" v-model="Priority">
                            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pone">Low</label>
                            
                            <input style="visibility:hidden;" type="radio" id="Ptwo" value="Medium" v-model="Priority">
                            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Ptwo">Medium</label>
                            
                            <input style="visibility:hidden;" type="radio" id="Pthree" value="High" v-model="Priority">
                            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pthree">High</label>
                            
                            <input style="visibility:hidden;" type="radio" id="Pfour" value="TOP" v-model="Priority">
                            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pfour">TOP</label>
                            </div>
                            Due Date : 
                            <input style="margin:5px;" v-model="DueDate" type="date" id="dueDate" name="dueDate">
                            <div style="margin:5px;" v-if="DueDate!=''">Due Date: {{DueDate}}</div>
                        </div>

                        <button type="button" @click="addTask()"
                        v-if="modalTitle=='Add Task'" class="btn btn-primary">
                        <img src="../assets/add_white_24dp.svg"/>
                        Add Task
                        </button>

                    </div>

                </div>

            </div>

        </div>

        </div>
        <div v-if="isVisible" class="boxtask" style="margin:10px;margin-left:900px;padding:5px;position:fixed;">
            <input type="text" class="form-control" v-model="Name" style="font-size:26px;border:none;border-bottom:1px solid black;">
            <br>
            <h5 style="margin:5px;">Favourite</h5>
            <input style="margin:5px;" type="radio" id="one" value=true v-model="Favourite">
            <label style="margin:5px;" for="one">Yes</label>
            <br>
            <input style="margin:5px;" type="radio" id="two" value=false v-model="Favourite">
            <label style="margin:5px;" for="two">No</label>

            <div style="margin:5px;">
                Category : 
                <select v-model="CategoryName">
                    <option v-for="cat in categories" :key="cat.TaskId">{{cat.CategoryName}}</option>
                </select>
            </div>

            <div style="margin:5px;">
            Priority : 
            <input style="visibility:hidden;" type="radio" id="Pone" value="Low" v-model="Priority">
            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pone">Low</label>
            <input style="visibility:hidden;" type="radio" id="Ptwo" value="Medium" v-model="Priority">
            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Ptwo">Medium</label>
            <input style="visibility:hidden;" type="radio" id="Pthree" value="High" v-model="Priority">
            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pthree">High</label>
            <input style="visibility:hidden;" type="radio" id="Pfour" value="TOP" v-model="Priority">
            <label class="btn btn-outline-dark" style="border-radius: 5px;cursor: pointer;" for="Pfour">TOP</label>
            </div>

            <div style="margin:5px;">
            Change Due Date : <input v-model="DueDate" type="date" id="dueDate" name="dueDate">
            <div v-if="DueDate!=''">Due Date: {{DueDate}}</div>
            </div>

            <button style="margin:5px;" type="button" @click="updateTask()"
            v-if="modalTitle!='Add Task'" class="btn btn-primary">
            <img src="../assets/edit_white_24dp.svg"/>
            Update Task
            </button>
    </div>
</template>

<script>
import API_URL from "../variables"
import axios from "axios"
export default {
    name:'TasksView',
    data()
    {
        return{
            tasks:[],
            tasks1:[],
            ctasks:[],
            categoryname:"",
            modalTitle:"",
            TaskId:0,
            Name:"",
            Priority:"Low",
            DueDate:"",
            CategoryName:"",
            IsDeleted:false,
            Favourite:false,
            DefaultCat:"",
            categories:[],
            selected:this.CategoryName,
            isVisible:false,
            CategoryId:0,
        }
    },

    methods:
    {
        async refreshData()
        {
            axios.get("http://localhost:30671/api/tasks/"+this.categoryname).then((response)=>{
                this.tasks=response.data;
                console.log(this.tasks)
            });

            console.log(this.tasks+" "+this.categoryname);
            axios.get("http://localhost:30671/api/category").then((response)=>{
                this.categories=response.data;
            });

            this.CategoryName=this.getDefaultCat();
            this.selected=this.getDefaultCat();
        },
        getTasks()
        {
            axios.get(API_URL+"tasks").then((response)=>{
                this.tasks1=response.data;
                this.refreshData();
                if(this.tasks1.length==0)
                {
                    console.log("ITS HEREin data "+response.data)
                }
                else
                {
                    console.log("ITS HEREin data else "+response.data)
                }
            });
        },
        getCategorizedTasks(categoryname)
        {
            console.log("ITS HERE "+categoryname)
            this.categoryname=categoryname;
            /*axios.get(variables.API_URL+"tasks/"+this.categoryname).then((response)=>{
                this.tasks=response.data;
                this.refreshData()
                console.log(this.tasks)
            });*/
        },
        addClick1()
        {
            this.isVisible=false
            this.refreshData();
            this.modalTitle="Add Task";
            this.Name="";
            this.Priority="Low";
            this.DueDate="";
            this.CategoryName=this.getDefaultCat();
            this.IsDeleted=false;
            this.Favourite=false;
            this.selected=this.getDefaultCat();
        },
        editClick1(task)
        {
            this.refreshData();
            this.modalTitle="Update Task";
            this.TaskId=task.TaskId;
            this.Name=task.Name;
            this.Priority=task.Priority;
            this.DueDate=task.DueDate;
            this.CategoryName=task.CategoryName;
            this.IsDeleted=task.IsDeleted;
            this.Favourite=task.Favourite;
            this.selected=task.CategoryName;
        },
        async addTask()
        {
            console.log(this.Name)
            console.log(this.Priority)
            console.log(this.Favourite)
            console.log(this.CategoryName)
            console.log(this.DueDate)
            console.log(this.selected)
            for(var i=0;i<this.categories.length;i++)
            {
                if(this.categories[i].CategoryName==this.CategoryName)
                {
                    console.log("we are heeee")
                    this.CategoryId=this.categories[i].CategoryId
                    break
                }
            }
            console.log(this.CategoryId)
            const today=new Date()
            var tdd = String(today.getDate()).padStart(2, '0');
            var tmm = String(today.getMonth() + 1).padStart(2, '0');
            var tyyyy = today.getFullYear();
            var dyyyy = this.DueDate.slice(0,4)
            var dmm = this.DueDate.slice(5,7)
            var ddd = this.DueDate.slice(8,10)
            console.log(today)
            console.log(tyyyy+tmm+tdd)
            console.log(dyyyy+dmm+ddd)
            const today1=new Date(this.DueDate)
            console.log(today1.toString().slice(0,15))
            this.DueDate=today1.toString().slice(0,15)
            if(tyyyy>dyyyy)
            {
                alert("Due Year Needs To be in Future")
                return null
            }
            else
            {
                if(tmm>dmm)
                {
                    alert("Due Month Needs To be in Future")
                    return null
                }
                else{
                    if(tdd>ddd)
                    {
                        alert("Due Date Needs To be in Future")
                        return null
                    }
                    else
                    {   
                        console.log("FINALLY")
                        const response=await axios.post("http://localhost:30671/api/tasks",{
                            Name:this.Name,
                            Priority:this.Priority,
                            DueDate:this.DueDate,
                            CategoryName:this.CategoryName,
                            IsDeleted:this.IsDeleted,
                            Favourite:this.Favourite,
                            CategoryId:this.CategoryId,
                        })
                        this.refreshData();
                        alert(response.data);
                    }
                }
            }
        },
        formatDate(date) 
        {
            var d = new Date(date),
                month = '' + (d.getMonth() + 1),
                day = '' + d.getDate(),
                year = d.getFullYear();
        
            if (month.length < 2) 
                month = '0' + month;
            if (day.length < 2) 
                day = '0' + day;
        
            return [year, month, day].join('-');
        },
        async updateTask()
        {
            console.log(this.DueDate)
            var dyyyy = this.DueDate.slice(0,4)
            var dmm = this.DueDate.slice(5,7)
            var ddd = this.DueDate.slice(8,10)
            console.log(dyyyy+dmm+ddd)
            const today1=new Date(this.DueDate)
            console.log(today1.toString().slice(0,15))
            this.DueDate=today1.toString().slice(0,15)
            console.log(this.DueDate)
            const response=await axios.patch("http://localhost:30671/api/updatetasks/"+this.TaskId,{
                TaskId:this.TaskId,
                Name:this.Name,
                Priority:this.Priority,
                DueDate:this.DueDate,
                CategoryName:this.CategoryName,
                IsDeleted:this.IsDeleted,
                Favourite:this.Favourite,   
            })
            this.refreshData();
            alert(response.data);
        },
        getDefaultCat()
        {
            for(var i=0;i<this.categories.length;i++)
                {
                    if(this.categories[i].IsDefault==true)
                    {
                        return this.categories[i].CategoryName;
                    }
                }
        },
        showTask(task)
        {
            console.log("YAY")
            if(this.isVisible==false)
            {
                this.isVisible=!this.isVisible
            }
            this.refreshData();
            this.modalTitle="Update Task";
            this.TaskId=task.TaskId;
            this.Name=task.Name;
            this.Priority=task.Priority;
            this.DueDate=task.DueDate;
            this.CategoryName=task.CategoryName;
            this.IsDeleted=task.IsDeleted;
            this.Favourite=task.Favourite;
            this.selected=task.CategoryName;
        },
    },

    updated(){
        console.log("UPDATED: "+this.tasks);
    },

    async mounted(){
        console.log("MOUNTED");
        const response=await axios.get("http://localhost:30671/api/tasks/"+this.categoryname)
        this.tasks=response.data
        this.refreshData();
        const response1= await axios.get("http://localhost:30671/api/category")
        this.categories=response1.data
        this.refreshData();
        const thisInstance=this
        this.emitter.on("getCatTasks",async (categoryname)=>{
            this.categoryname=categoryname
            const response=await axios.get("http://localhost:30671/api/tasks/"+this.categoryname)
            this.tasks=response.data
            this.refreshData();
        })
    },
}
</script>

<style>
    input#Pone[type="radio"]:checked + label
    {
        border-radius: 5px;
        background-color: blue;
    }
    input#Ptwo[type="radio"]:checked + label
    {
        border-radius: 5px;
        background-color: yellow;
    }
    input#Pthree[type="radio"]:checked + label
    {
        border-radius: 5px;
        background-color: orange;
    }
    input#Pfour[type="radio"]:checked + label
    {
        border-radius: 5px;
        background-color: red;
    }
</style>