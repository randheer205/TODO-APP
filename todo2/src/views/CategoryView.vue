<template>
<div style="max-width:15%;">

    <div style="display:grid;text-align:center;">
        <h5>Categories</h5>
        <button type="button" class="btn btn-primary m-2" data-bs-toggle="modal" data-bs-target="#exampleModal" @click="addClick()"><img src="../assets/add_white_24dp.svg"/></button>
    </div>

    <div v-for="cat in categories" :key="cat.CategoryId">
        <button class="btn btn-outline-secondary" v-if="cat.IsDefault==true" style="border:none;background:blue;min-width:100%;color:white;" @click="gct(cat.CategoryName)">{{cat.CategoryName}}</button>
        <button class="btn btn-outline-secondary" v-else @click="gct(cat.CategoryName)" style="border:none;min-width:100%;color:black;" >{{cat.CategoryName}}</button>
    </div>

    <div class="modal fade" id="exampleModal" tabIndex="-1"
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
                        <span class="input-group-text">Category Name</span>
                        <input type="text" class="form-control" v-model="CategoryName">
                        <br>
                        <h5>IsDefault</h5>
                        <input type="radio" id="one" value=true v-model="IsDefault">
                        <label for="one">True</label>
                        <br>
                        <input type="radio" id="two" value=false v-model="IsDefault">
                        <label for="two">False</label>
                    </div>

                    <button type="button" @click="addCategory()"
                    v-if="modalTitle=='Add Category'" class="btn btn-primary">
                    Add Category
                    </button>

                    <button type="button" @click="updateCategory()"
                    v-if="modalTitle!='Add Category'" class="btn btn-primary">
                    Update Category
                    </button>
                </div>

            </div>

        </div>

    </div>

</div>
</template>

<script>
import axios from "axios"
export default {
    data()
    {
        return{
            categories:[],
            modalTitle:"",
            CategoryName:"",
            IsDefault:false,
            CategoryId:0,
        }
    },
    
    methods:
    {
        async refreshData(){
            try
            {
                const result=await axios.get("http://localhost:30671/api/category")
                this.categories=result.data
            }
            catch(exception)
            {
                console.log(result)
            }

        },
        addClick(){
            this.modalTitle="Add Category";
            this.CategoryName="";
            this.IsDefault=false;
        },
        editClick(cat)
        {
            this.modalTitle="Update Category";
            this.CategoryId=cat.CategoryId;
            this.CategoryName=cat.CategoryName;
            this.IsDefault=cat.IsDefault;
        },
        async addCategory()
        {
            for(var i=0;i<this.categories.length;i++){
                if(this.categories[i].CategoryName==this.CategoryName)
                {
                    alert("Category Already Exist")
                    return null
                }
            }
            await axios.post("http://localhost:30671/api/category",{
                CategoryName:this.CategoryName,
                IsDefault:this.IsDefault
            }).then((response)=>{
                this.refreshData();
                alert(response.data);
            })
        },
        async updateCategory()
        {
            await axios.patch("http://localhost:30671/api/category"+this.CategoryId,{
                CategoryId:this.CategoryId,
                CategoryName:this.CategoryName,
                IsDefault:this.IsDefault
            }).then((response)=>{
                this.refreshData();
                alert(response.data);
            })
        },
        gct(categoryname)
        {
            //tasks.methods.getCategorizedTasks(categoryname);
            //this.$emit("getCatTasks",categoryname);
            this.emitter.emit("getCatTasks",categoryname)
        }
    },
    
    mounted:function()
    {
        this.refreshData();
    }

}
</script>

<style>

</style>